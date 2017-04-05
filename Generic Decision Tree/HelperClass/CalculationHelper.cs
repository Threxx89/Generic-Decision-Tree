using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree.HelperClass
{
   public static class CalculationHelper
    {
        ///<summary>
        ///Entropy
        ///</summary>
        /// <remarks> 
        /// A logarithmic measure of the rate of transfer of information in a particular message or language.
        /// Calculates entropy per attribute subset values.
        /// </remarks>
        public static double Entropy(double total, double value)
        {
            double answer = value / total;
            if (answer == 0)
            {
                return answer;
            }
            return -answer * Math.Log(answer, 2);
        }

        ///<summary>
        ///EntropyPerAttribute
        ///</summary>
        /// <remarks> 
        /// Uses entropy caluclate for each sub set in an attribute to get column entropy.
        /// </remarks>
        public static double EntropyPerAttribute(double[] entropyValues)
        {
            double value = 0;

            for (int i = 0; i < entropyValues.Length; i++)
            {
                value = value + entropyValues[i];
            }

            return value;
        }


        ///<summary>
        ///InfoGainMultiplication
        ///</summary>
        /// <remarks> 
        /// Calculates the multiplication part of the InfoGain formula.
        /// The value return here still needs to be subtracted from the Answer Entropy and other sub values of this attribute type.
        /// </remarks>
        public static double InfoGainMultiplication(double total, double value, double entropyPerAttribute)
        {
            double answer = value / total;
            return answer * entropyPerAttribute;
        }


        ///<summary>
        ///InfoGain
        ///</summary>
        /// <remarks> 
        /// Does the final subtraction the info gain formula require and return the answer to the equation.
        /// </remarks>
        public static double InfoGain(double answerAttributeEntropy, double[] infoGainMultiplication)
        {
            for (int i = 0; i < infoGainMultiplication.Length; i++)
            {
                answerAttributeEntropy = answerAttributeEntropy - infoGainMultiplication[i];
            }

            return answerAttributeEntropy;
        }
    }
}
