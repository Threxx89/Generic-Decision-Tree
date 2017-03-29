using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Node<PlayTennis> tennisTree = new Node<PlayTennis>("PlayTennis",playTennisDays, null);

            Console.WriteLine(tennisTree.MakeDecision(new PlayTennis("overcast", "mild", "high", "strong")));

            List<PlayGames> playGames = new List<PlayGames>();
            playGames.Add(new PlayGames("yes", "yes", "night", true));
            playGames.Add(new PlayGames("maybe", "yes", "day", false));
            playGames.Add(new PlayGames("yes", "no", "night", true));
            playGames.Add(new PlayGames("no", "no", "day", false));
            playGames.Add(new PlayGames("no", "no", "night", false));
            playGames.Add(new PlayGames("yes", "yes", "night", true));
            playGames.Add(new PlayGames("maybe", "yes", "day", false));
            playGames.Add(new PlayGames("yes", "no", "day", false));
            playGames.Add(new PlayGames("maybe", "no", "night", true));
            playGames.Add(new PlayGames("no", "yes", "day", false));
            playGames.Add(new PlayGames("yes", "no", "night", true));
            playGames.Add(new PlayGames("yes", "no", "day", false));
            playGames.Add(new PlayGames("yes", "yes", "night", true));
            playGames.Add(new PlayGames("yes", "yes", "night", true));

            Node<PlayGames> playGamesNode = new Node<PlayGames>("PlayGames", playGames, null);

            Console.WriteLine(playGamesNode.MakeDecision(new PlayGames("yes", "yes", "night")));

            Console.ReadKey();
       

        
        }
    }
}
