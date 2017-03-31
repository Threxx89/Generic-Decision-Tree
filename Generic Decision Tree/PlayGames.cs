﻿using Generic_Decision_Tree.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree
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
        [ClassCriteriaAttribute()]
        public string Excited { get => m_Excited; set => m_Excited = value; }
        [ClassCriteriaAttribute()]
        public string Hungry { get => m_Hungry; set => m_Hungry = value; }
        [ClassCriteriaAttribute()]
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