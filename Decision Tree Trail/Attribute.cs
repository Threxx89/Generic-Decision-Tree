using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
    public class Attribute
    {
        #region PrivateMember
        private string m_Name;
        private Dictionary<string, Choice> m_ChoiceCount;
        private int m_Count;
        private double m_ClassObjectEntropy;
        #endregion

        #region Properties
        public string Name { get => m_Name; set => m_Name = value; }
        public Dictionary<string, Choice> ChoiceCount { get => m_ChoiceCount; }
        public double ClassObjectEntropy{ get => m_ClassObjectEntropy; }
        public double InfoGain
        {
            get { return _InfoGain(); }
        }

        public double Count { get => m_Count; }
        #endregion

        public Attribute(string name)
        {
            Name = name;
            m_ChoiceCount = new Dictionary<string, Choice>();
        }

        public Attribute()
        {

        }

        public void AddData(string choice, bool yesNo, double classObjectEntropy)
        {
            if (!m_ChoiceCount.ContainsKey(choice.ToUpper()))
            {
                m_ChoiceCount.Add(choice.ToUpper(), new Choice());
            }

            m_ChoiceCount[choice.ToUpper()].GiveAnswer(yesNo);
            m_ClassObjectEntropy = classObjectEntropy;
            m_Count++;
        }

        private double _InfoGain()
        {
            List<double> answers = new List<double>(m_ChoiceCount.Count);
            foreach (string key in m_ChoiceCount.Keys)
            {
                answers.Add(CalculationHelper.thingy(m_Count, m_ChoiceCount[key].ChoiceCount, m_ChoiceCount[key].Entropy));
            }
            return m_ClassObjectEntropy - CalculationHelper.EntropyS(answers.ToArray());
        }
    }
}

