using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_It.CustomControls
{
    public partial class SMSComponent : System.ComponentModel.Component
    {

        DAL.SYSProperty _Properties;
        public SMSComponent(DAL.SYSProperty Properties)
        {   InitializeComponent();
        _Properties = Properties;
        }
        string api_token;
        string api_secret;
        public SMSComponent(string api_token, string api_secret)
        {
            InitializeComponent();
            this.api_secret = api_secret;
            this.api_token = api_token;
        }


        public string send(string number, string message)
        {
            try
            {

                string username = api_secret;// ConfigurationManager.AppSettings["SMSUserName"].ToString();
                string password = api_token;//ConfigurationManager.AppSettings["SMSPassword"].ToString();
                System.Diagnostics.Debug.Print(" Message: " + message);
                //http://lifetimesms.com/plain?api_token=a54303719a573938f01282ca34717a55fa02f62330&api_secret=34334&to923242331164&from=SmartSMS&message=Date:%209/29/2019%209:56:42%20PM%0D%0ATime:%205:46%20PM%0D%0AInstrument:%20Ultra%20High%0D%0ATemperature%20%20=%2031.5%20C%20%0D%0ADescription:%20%0D%0AALERT!%20Temperature%20is%20High
                System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://Lifetimesms.com/plain?api_token="
                + password + "&api_secret=" + username + "&to=" + number + "&from=" + ConfigurationManager.AppSettings["SMSFrom"] + "&message=" + Uri.UnescapeDataString(message));

                System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());//.GET / POSTResponseStream());

                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();

                myResp.Close();
                Technoman.Utilities.EventClass.WriteLog(responseString);

                return responseString;
            }
            catch (Exception m)
            {
                Technoman.Utilities.EventClass.WriteLog(m.Message);
                return "Failed to send SMS";
                //Dispose(true);
            }

        }

        public bool send(List<string> No, string message)
        {
            try
            {

                string username = _Properties.SMSToken;// ConfigurationManager.AppSettings["SMSUserName"].ToString();
                string password = _Properties.SMSSecret;//ConfigurationManager.AppSettings["SMSPassword"].ToString();
                System.Diagnostics.Debug.Print(" Message: " + message);
                foreach (var item in No)
                {
                    //http://lifetimesms.com/plain?api_token=a54303719a573938f01282ca34717a55fa02f62330&api_secret=34334&to923242331164&from=SmartSMS&message=Date:%209/29/2019%209:56:42%20PM%0D%0ATime:%205:46%20PM%0D%0AInstrument:%20Ultra%20High%0D%0ATemperature%20%20=%2031.5%20C%20%0D%0ADescription:%20%0D%0AALERT!%20Temperature%20is%20High
                    System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://Lifetimesms.com/plain?api_token="
                    + username + "&api_secret=" + password + "&to=" + item + "&from=" + ConfigurationManager.AppSettings["SMSFrom"] + "&message=" + Uri.UnescapeDataString(message));

                    System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)myReq.GetResponse();
                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());//.GET / POSTResponseStream());

                    string responseString = respStreamReader.ReadToEnd();
                    respStreamReader.Close();

                    myResp.Close();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
                //Dispose(true);
            }

        }
        public SMSComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
