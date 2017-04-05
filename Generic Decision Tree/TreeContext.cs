using Generic_Decision_Tree.DecisionTreeClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Generic_Decision_Tree
{
    public class TreeContext : DbContext
    {
        public DbSet<PlayGames> PlayGames  { get; set; }
        public DbSet<PlayTennis> PlayTennis { get; set; }
        private static volatile TreeContext instance;
        private static object syncRoot = new Object();

        public static TreeContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TreeContext();
                    }
                }

                return instance;
            }
        }
    }
}
