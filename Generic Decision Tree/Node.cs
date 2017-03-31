using Generic_Decision_Tree.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree
{
   public class Node<T>
    {
        #region PrivateMember
        private string m_Name;
        private Choice m_Chosen;
        private List<Node<T>> m_Decisions;
        private string m_ColumnAttributeName;
        private List<T> m_DataSet;
        private List<ColumnAttribute> m_Attributes;
        private bool? m_Answer =null;
        #endregion

        #region Properties
        public string Name { get => m_Name; set => m_Name = value; }
        public List<ColumnAttribute> Attributes { get => m_Attributes;}
        public Choice Chosen { get => m_Chosen;}
        public string AttributeName { get => m_ColumnAttributeName; }
        #endregion

        public Node(string name, List<T> data,bool? answer)
        {
            Name = name;
            m_Attributes = new List<ColumnAttribute>();
            m_Decisions = new List<Node<T>>();
            m_Chosen = new Choice();
            m_DataSet = data;
            m_Answer = answer;

            BuildDecisionTree();
        }

        ///<summary>
        ///ColumnAttribute
        ///</summary>
        /// <remarks> 
        /// Ad
        /// </remarks>
        public void AddColumnAttribute(string attributeName, string choice, bool yesNo, double classObjectEntropy)
        {
            ColumnAttribute selectedAttribute = m_Attributes.FirstOrDefault(x => x.Name.ToUpper() == attributeName.ToUpper());

           if(!m_Attributes.Contains(selectedAttribute))
            {
                ColumnAttribute newAttribute = new ColumnAttribute(attributeName);
                newAttribute.AddData(choice, yesNo, classObjectEntropy);
                m_Attributes.Add(newAttribute);
            }
           else
            {
                m_Attributes.FirstOrDefault(x => x.Name.ToUpper() == attributeName.ToUpper()).AddData(choice, yesNo,classObjectEntropy);
            }
        }

        public bool? MakeDecision(T tennis)
        {
            bool? answer = m_Answer;
            if (m_Decisions.Count >0)
            {
                foreach (Node<T> choice in m_Decisions)
                {
                    string s = Convert.ToString(tennis.GetType().GetProperty(AttributeName).GetValue(tennis)).ToUpper();
                    if (choice.Name == Convert.ToString(tennis.GetType().GetProperty(AttributeName).GetValue(tennis)).ToUpper())
                    {
                       answer = choice.MakeDecision(tennis);
                    }
                }
            }
            return answer;
        }


        ///<summary>
        ///Get Best Info Gain Attribute
        ///</summary>
        /// <remarks> 
        /// Looks through all given attributes and return the attribute with the highest info gian value.
        /// </remarks>
        private ColumnAttribute GetBestInfoGainAttribute(List<ColumnAttribute> attributes) 
        {
            ColumnAttribute selectedValue = null;
            double highValue = 0;
            foreach (ColumnAttribute selectedAttribute in attributes)
            {
                if (highValue < selectedAttribute.InfoGain)
                {
                    highValue = selectedAttribute.InfoGain;
                    selectedValue = selectedAttribute;
                    m_ColumnAttributeName = selectedValue.Name;
                }
            }
            return selectedValue;
        }

        ///<summary>
        ///Build Decision Tree
        ///</summary>
        /// <remarks> 
        /// Evaluates historical date and create a decision tree to prodict future answer for given data
        /// </remarks>
        private void BuildDecisionTree()
        {
            PropertyInfo[] ClassAnswerAttributes = typeof(T).GetProperties().Where(x => System.Attribute.IsDefined(x,typeof(ClassCriteriaAttribute))).ToArray();
            PropertyInfo ClassAnswerAttribute = typeof(T).GetProperties().FirstOrDefault(x => System.Attribute.IsDefined(x, typeof(ClassAnswerAttribute)));

            if (m_DataSet.Where(x => Convert.ToBoolean(x.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(x)) == true).Count() == m_DataSet.Count)
            {
                m_Answer = true;
            }
            else if (m_DataSet.Where(x => Convert.ToBoolean(x.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(x)) == false).Count() == m_DataSet.Count)
            {
                m_Answer = false;
            }

            if (m_Answer == null)
            {
                foreach (T dataRow in m_DataSet)
                {
                    this.Chosen.GiveAnswer(Convert.ToBoolean(dataRow.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(dataRow)));

                    foreach (PropertyInfo attribute in ClassAnswerAttributes)
                    {
                        this.AddColumnAttribute(
                            attribute.Name,
                            Convert.ToString(dataRow.GetType().GetProperty(attribute.Name).GetValue(dataRow)),
                            Convert.ToBoolean(dataRow.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(dataRow)),
                            this.Chosen.Entropy);
                    }
                }

                ColumnAttribute selectedAttribute = GetBestInfoGainAttribute(this.Attributes);

                if (selectedAttribute != null)
                {
                    foreach (KeyValuePair<string, Choice> chosen in selectedAttribute.ChoiceCount)
                    {
                        List<T> newData = m_DataSet.Where(x => Convert.ToString(x.GetType().GetProperty(selectedAttribute.Name).GetValue(x)).ToUpper() == chosen.Key).ToList();
                        m_Decisions.Add(new Node<T>(chosen.Key, newData, m_Answer));
                    }

                }
            }
        }
    }
}
