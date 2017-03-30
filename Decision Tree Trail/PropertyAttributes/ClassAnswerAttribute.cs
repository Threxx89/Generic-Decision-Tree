using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree.PropertyAttributes
{
   public class ClassAnswerAttribute : DisplayNameAttribute
    {
        #region Private Member
        private string m_Name;
        #endregion

        #region Constructor
        public ClassAnswerAttribute(string name)
        {
            m_Name = name;
        }
       
        public ClassAnswerAttribute()
        {

        }
        #endregion

        #region Properties
        public string Name { get => m_Name;}
        #endregion
    }
}
