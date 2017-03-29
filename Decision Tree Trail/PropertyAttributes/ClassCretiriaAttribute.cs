﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail.PropertyAttributes
{
    public class ClassCretiriaAttribute : DisplayNameAttribute
    {
        private string m_Name;

        public string Name { get => m_Name; set => m_Name = value; }

        public ClassCretiriaAttribute()
        {

        }

        public ClassCretiriaAttribute(string name)
        {
            m_Name = name;
        }
    }
}