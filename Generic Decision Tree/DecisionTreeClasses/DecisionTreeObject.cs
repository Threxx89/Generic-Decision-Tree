using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree.DecisionTreeClasses
{
    public abstract class DecisionTreeObject
    {
        [Key]
        public int Id { get; set; }
        public virtual string Name { get { return "Decision Tree Object"; } }

        public abstract void CreateObject();
        public abstract void UpdateObject();

    }
}
