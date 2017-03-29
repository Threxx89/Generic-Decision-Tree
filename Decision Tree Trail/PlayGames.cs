using Decision_Tree_Trail.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
    public class PlayGames
    {
        #region Private Members
        private string m_Excited;
        private string m_Hungry;
        private string m_TimeOfDay;
        private bool m_PlayGame;
        #endregion

        #region Properties
        [ClassCretiriaAttribute()]
        public string Excited { get => m_Excited; set => m_Excited = value; }
        [ClassCretiriaAttribute()]
        public string Hungry { get => m_Hungry; set => m_Hungry = value; }
        [ClassCretiriaAttribute()]
        public string TimeOfDay { get => m_TimeOfDay; set => m_TimeOfDay = value; }

        [ClassAnswerAttribute()]
        public bool Playgames { get => m_PlayGame; set => m_PlayGame = value; }
        #endregion

        #region Constructor
        public PlayGames(string excited, string hungry, string timeofday, bool playGames)
        {
            Hungry = hungry;
            Playgames = playGames;
            TimeOfDay = timeofday;
            Excited = excited;
        }

        public PlayGames(string excited, string hungry, string timeofday)
        {
            Hungry = hungry;
            TimeOfDay = timeofday;
            Excited = excited;
        }
        #endregion
    }
}
