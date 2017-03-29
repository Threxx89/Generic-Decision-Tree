using Decision_Tree_Trail.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
   public class Node<T>
    {
        #region PrivateMember
        private string m_Name;
        private Choice m_Chosen;
        private List<Node<T>> m_Decisions;
        private string m_AttributeName;
        private List<T> m_DataSet;
        private List<Attribute> m_Attributes;
        private bool? m_Answer =null;
        #endregion

        #region Properties
        public string Name { get => m_Name; set => m_Name = value; }
        public List<Attribute> Attributes { get => m_Attributes;}
        public Choice Chosen { get => m_Chosen;}
        public string AttributeName { get => m_AttributeName; }
        #endregion

        public Node(string name, List<T> data,bool? answer)
        {
            Name = name;
            m_Attributes = new List<Attribute>();
            m_Decisions = new List<Node<T>>();
            m_Chosen = new Choice();
            m_DataSet = data;
            m_Answer = answer;

            DoThings();
        }

        public void AddAttribute(string attributeName, string choice, bool yesNo, double classObjectEntropy)
        {
            Attribute selectedAttribute = m_Attributes.FirstOrDefault(x => x.Name.ToUpper() == attributeName.ToUpper());

           if(!m_Attributes.Contains(selectedAttribute))
            {
                Attribute newAttribute = new Attribute(attributeName);
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

        private void DoThings()
        {
            PropertyInfo[] ClassAnswerAttributes = typeof(T).GetProperties().Where(x => System.Attribute.IsDefined(x,typeof(ClassCretiriaAttribute))).ToArray();
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
                foreach (T tennisDay in m_DataSet)
                {
                    this.Chosen.GiveAnswer(Convert.ToBoolean(tennisDay.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(tennisDay)));

                    foreach (PropertyInfo attribute in ClassAnswerAttributes)
                    {
                        this.AddAttribute(
                            attribute.Name,
                            Convert.ToString(tennisDay.GetType().GetProperty(attribute.Name).GetValue(tennisDay)),
                            Convert.ToBoolean(tennisDay.GetType().GetProperty(ClassAnswerAttribute.Name).GetValue(tennisDay)),
                            this.Chosen.Entropy);
                    }
                }

                Attribute selectedValue = null;
                double highValue = 0;
                foreach (Attribute selectedAttribuite in this.Attributes)
                {
                    if (highValue < selectedAttribuite.InfoGain)
                    {
                        highValue = selectedAttribuite.InfoGain;
                        selectedValue = selectedAttribuite;
                        m_AttributeName = selectedValue.Name;
                    }
                }

                if (selectedValue != null)
                {
                    foreach (KeyValuePair<string, Choice> chosen in selectedValue.ChoiceCount)
                    {
                        List<T> newData = m_DataSet.Where(x => Convert.ToString(x.GetType().GetProperty(selectedValue.Name).GetValue(x)).ToUpper() == chosen.Key).ToList();
                        m_Decisions.Add(new Node<T>(chosen.Key, newData, m_Answer));
                    }

                }
            }
        }
    }
}
