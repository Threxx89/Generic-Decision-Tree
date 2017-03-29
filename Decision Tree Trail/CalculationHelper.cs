using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
   public static class CalculationHelper
    {
        public static double Entropy(double total, double value)
        {
            double answer = value / total;
            if (answer == 0)
            {
                return answer;
            }
            return -answer * Math.Log(answer, 2);
        }

        public static double EntropyS(double[] entropyValues)
        {
            double value = 0;

            for (int i = 0; i < entropyValues.Length; i++)
            {
                value = value + entropyValues[i];
            }

            return value;
        }

        public static double thingy(double total, double value, double entropyS)
        {
            double answer = value / total;
            return answer * entropyS;
        }

        public static double InfoGain(double m, double[] thingy)
        {
            for (int i = 0; i < thingy.Length; i++)
            {
                m = m - thingy[i];
            }

            return m;
        }
    }
}
