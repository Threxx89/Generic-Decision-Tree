using Generic_Decision_Tree.DecisionTreeClasses;
using Generic_Decision_Tree.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Decision_Tree
{
    public class PlayTennis : DecisionTreeObject
    {
        #region Private Members
        private string m_Outlook;
        private string m_Temperature;
        private string m_Humidity;
        private string m_Wind;
        private bool m_PlayTennis;
        #endregion

        #region Properties
        [ClassCriteriaAttribute()]
        public string Outlook { get => m_Outlook; set => m_Outlook = value; }
        [ClassCriteriaAttribute()]
        public string Temperature { get => m_Temperature; set => m_Temperature = value; }
        [ClassCriteriaAttribute()]
        public string Humidity { get => m_Humidity; set => m_Humidity = value; }
        [ClassCriteriaAttribute()]
        public string Wind { get => m_Wind; set => m_Wind = value; }

        [ClassAnswerAttribute()]
        public bool PlayTenniss { get => m_PlayTennis; set => m_PlayTennis = value; }

        [NotMapped]
        public override string Name => "Play Tennis";
        #endregion

        #region Constructor
        public PlayTennis(string outlook, string temperature, string humidity, string wind, bool playTennis )
        {
            Humidity = humidity;
            Outlook = outlook;
            PlayTenniss = playTennis;
            Temperature = temperature;
            Wind = wind;
        }

        public PlayTennis(string outlook, string temperature, string humidity, string wind)
        {
            Humidity = humidity;
            Outlook = outlook;
            Temperature = temperature;
            Wind = wind;
        }


        #endregion


        public override void CreateObject()
        {
            TreeContext.Instance.PlayTennis.Add(this);
            TreeContext.Instance.SaveChanges();
        }

        public override void UpdateObject()
        {
            throw new NotImplementedException();
        }
    }
}
