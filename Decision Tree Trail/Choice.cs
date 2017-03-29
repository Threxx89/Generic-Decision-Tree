using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
   public class Choice
    {
        private int m_ChoiceCount;
        private int m_TrueCount;
        private int m_FalseCount;
        private double m_Entropy;

        public int ChoiceCount { get => m_ChoiceCount;}
        public int TrueCount { get => m_TrueCount;}
        public int FalseCount { get => m_FalseCount;}
        public double Entropy { get => m_Entropy;}

        public Choice()
        {

        }

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
           m_Entropy = _CalculateEntropry();
        }

        private double _CalculateEntropry()
        {
            List<double> answers = new List<double>(m_ChoiceCount);
            answers.Add(CalculationHelper.Entropy(m_ChoiceCount, m_FalseCount));
            answers.Add(CalculationHelper.Entropy(m_ChoiceCount, m_TrueCount));

            return CalculationHelper.EntropyS(answers.ToArray());
        }
    }
}
