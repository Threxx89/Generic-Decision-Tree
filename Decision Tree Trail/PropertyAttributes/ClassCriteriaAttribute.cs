using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree.PropertyAttributes
{
    ///<summary>
    ///Class Criteria Attribute
    ///</summary>
    /// <remarks> 
    /// Use to Identify the criteria column in our class which will be used to determin the answer.
    /// </remarks>
    
    public class ClassCriteriaAttribute : DisplayNameAttribute
    {
        #region Private Member
        private string m_Name;
        #endregion

        #region Properties
        public string Name { get => m_Name; }
        #endregion

        #region Constructor
        public ClassCriteriaAttribute(string name)
        {
            m_Name = name;
        }

        public ClassCriteriaAttribute()
        {

        }
        #endregion
    }
}
