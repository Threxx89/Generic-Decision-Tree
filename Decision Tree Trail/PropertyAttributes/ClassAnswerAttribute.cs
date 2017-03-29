using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail.PropertyAttributes
{
   public class ClassAnswerAttribute : DisplayNameAttribute
    {
        private string m_Name;

        public ClassAnswerAttribute(string name)
        {
            m_Name = name;
        }
        public ClassAnswerAttribute()
        {

        }

        public string Name { get => m_Name;}
    }
}
