using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree
{
    ///<summary>
    ///Column Attribute
    ///</summary>
    /// <remarks> 
    /// Gains information on a specific defined attribute.
    /// Looks at what the attributes value was and what was the answer when this attribute was that value.
    /// </remarks>

    public class ColumnAttribute
    {
        #region PrivateMember
        private string m_Name;
        private Dictionary<string, Choice> m_ChoiceCount;
        private int m_Count;
        private double m_answerAttributeEntropy;
        #endregion

        #region Properties
        public string Name { get => m_Name; set => m_Name = value; }

        public Dictionary<string, Choice> ChoiceCount { get => m_ChoiceCount; }

        public double AnswerAttributeEntropy { get => m_answerAttributeEntropy; }

        public double InfoGain
        {
            get { return _InfoGain(); }
        }

        public double Count { get => m_Count; }
        #endregion

        #region Constructor
        public ColumnAttribute(string name)
        {
            Name = name;
            m_ChoiceCount = new Dictionary<string, Choice>();
        }

        public ColumnAttribute()
        {

        }
        #endregion

        #region Public Methods
        ///<summary>
        ///Add Date
        ///</summary>
        /// <remarks> 
        /// Gathers needed data about the specified attribute in order to make accurate calculations.
        /// </remarks>
        public void AddData(string choice, bool answerAttributeValue, double answerAttributeEntropy)
        {
            if (!m_ChoiceCount.ContainsKey(choice.ToUpper()))
            {
                m_ChoiceCount.Add(choice.ToUpper(), new Choice());
            }

            m_ChoiceCount[choice.ToUpper()].GiveAnswer(answerAttributeValue);
            m_answerAttributeEntropy = answerAttributeEntropy;
            m_Count++;
        }
        #endregion

        #region Private Methods
        ///<summary>
        ///_InfoGain
        ///</summary>
        /// <remarks> 
        /// Calculates the Info Gain for the specified attribute.
        /// </remarks>
        private double _InfoGain()
        {
            List<double> answers = new List<double>(m_ChoiceCount.Count);
            foreach (string key in m_ChoiceCount.Keys)
            {
                answers.Add(CalculationHelper.InfoGainMultiplication(m_Count, m_ChoiceCount[key].ChoiceCount, m_ChoiceCount[key].Entropy));
            }
            return m_answerAttributeEntropy - CalculationHelper.EntropyPerAttribute(answers.ToArray());
        }
        #endregion
    }
}

