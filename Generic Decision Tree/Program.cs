using Generic_Decision_Tree.DecisionTreeClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Generic_Decision_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeContext.Instance.Database.Delete();

            List<PlayTennis> playTennisDays = new List<PlayTennis>();
            playTennisDays.Add(new PlayTennis("sunny", "hot", "high", "strong", false));
            playTennisDays.Add(new PlayTennis("sunny", "hot", "high", "weak", false));
            playTennisDays.Add(new PlayTennis("overcast", "hot", "high", "weak", true));
            playTennisDays.Add(new PlayTennis("rain", "mild", "high", "weak", true));
            playTennisDays.Add(new PlayTennis("rain", "cool", "normal", "weak", true));
            playTennisDays.Add(new PlayTennis("rain", "cool", "normal", "strong", false));
            playTennisDays.Add(new PlayTennis("overcast", "cool", "normal", "strong", true));
            playTennisDays.Add(new PlayTennis("sunny", "mild", "high", "weak", false));
            playTennisDays.Add(new PlayTennis("sunny", "cool", "normal", "weak", true));
            playTennisDays.Add(new PlayTennis("rain", "mild", "normal", "weak", true));
            playTennisDays.Add(new PlayTennis("sunny", "mild", "normal", "strong", true));
            playTennisDays.Add(new PlayTennis("overcast", "mild", "high", "strong", true));
            playTennisDays.Add(new PlayTennis("overcast", "hot", "normal", "weak", true));
            playTennisDays.Add(new PlayTennis("rain", "mild", "high", "strong", false));

            TreeContext.Instance.PlayTennis.AddRange(playTennisDays);
            TreeContext.Instance.SaveChanges();
            var query = from c in TreeContext.Instance.PlayTennis
                        select c;

             Node<PlayTennis> tennisTree = new Node<PlayTennis>("PlayTennis",playTennisDays, null);

             Console.WriteLine(tennisTree.MakeDecision(new PlayTennis("overcast", "mild", "high", "strong")));


            Console.ReadKey();
       

        
        }
    }
}
