using Generic_Decision_Tree.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree
{
    ///<summary>
    ///Choice
    ///</summary>
    /// <remarks> 
    /// Keeps track of the answer or choice made on the column answer attribute.
    /// Makes use of this information to calculate entropy.
    /// </remarks>

    public class Choice
    {
        #region Private Members
        private int m_ChoiceCount;
        private int m_TrueCount;
        private int m_FalseCount;
        private double m_Entropy;
        #endregion

        #region Properties
        public int ChoiceCount { get => m_ChoiceCount;}
        public int TrueCount { get => m_TrueCount;}
        public int FalseCount { get => m_FalseCount;}
        public double Entropy { get => m_Entropy;}
        #endregion

        #region Constructor
        public Choice()
        {

        }
        #endregion

        #region Public Methods
        public void GiveAnswer(bool answer)
        {
            if (answer)
            {
                m_TrueCount++;
            }
            else
            {
                m_FalseCount++;
            }
            m_ChoiceCount++;
           m_Entropy = _CalculateEntropy();
        }
        #endregion

        #region Private Methods
        private double _CalculateEntropy()
        {
            List<double> answers = new List<double>(m_ChoiceCount);
            answers.Add(CalculationHelper.Entropy(m_ChoiceCount, m_FalseCount));
            answers.Add(CalculationHelper.Entropy(m_ChoiceCount, m_TrueCount));

            return CalculationHelper.EntropyPerAttribute(answers.ToArray());
        }
        #endregion
    }
}
