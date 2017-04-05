using Generic_Decision_Tree.PropertyAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Generic_Decision_Tree.DecisionTreeClasses
{
    public class PlayGames : DecisionTreeObject
    {
        #region Private Members
        private string m_Excited;
        private string m_Hungry;
        private string m_TimeOfDay;
        private bool m_PlayGame;
        #endregion

        #region Properties
        [StringLength(20)]
        [ClassCriteriaAttribute()]
        public string Excited { get => m_Excited; set => m_Excited = value; }
        [StringLength(20)]
        [ClassCriteriaAttribute()]
        public string Hungry { get => m_Hungry; set => m_Hungry = value; }
        [StringLength(20)]
        [ClassCriteriaAttribute()]
        public string TimeOfDay { get => m_TimeOfDay; set => m_TimeOfDay = value; }
        [ClassAnswerAttribute()]
        public bool Playgames { get => m_PlayGame; set => m_PlayGame = value; }
        [NotMapped]
        public override string Name => "Play Games";
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

        public PlayGames()
        {

        }

        public override void CreateObject()
        {
            TreeContext.Instance.PlayGames.Add(this);
            TreeContext.Instance.SaveChanges();
        }

        public override void UpdateObject()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
