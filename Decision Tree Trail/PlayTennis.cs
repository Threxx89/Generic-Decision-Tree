using Decision_Tree_Trail.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Decision_Tree_Trail
{
    public class PlayTennis
    {
        #region Private Members
        private string m_Outlook;
        private string m_Temperature;
        private string m_Humidity;
        private string m_Wind;
        private bool m_PlayTennis;
        #endregion

        #region Properties
        [ClassCretiriaAttribute()]
        public string Outlook { get => m_Outlook; set => m_Outlook = value; }
        [ClassCretiriaAttribute()]
        public string Temperature { get => m_Temperature; set => m_Temperature = value; }
        [ClassCretiriaAttribute()]
        public string Humidity { get => m_Humidity; set => m_Humidity = value; }
        [ClassCretiriaAttribute()]
        public string Wind { get => m_Wind; set => m_Wind = value; }

        [ClassAnswerAttribute()]
        public bool PlayTenniss { get => m_PlayTennis; set => m_PlayTennis = value; }
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
    }
}
