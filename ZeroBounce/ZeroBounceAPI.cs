using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroBounce.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace ZeroBounce
{

    public class ZeroBounceAPI
    {
        // "Your API Key";
        private string m_apiKey = "";
        public string ApiKey
        {
             get
            {
                return m_apiKey;
            }

             set
            {
                m_apiKey = value;
            }
        }
        // "Your IP address";
        private string m_IPAddress = "";
        public string IpAddress
        {
            get
            {
                return m_IPAddress;
            }

            set
            {
                m_IPAddress = value;
            }
        }
        private string m_emailToValidate = "";
        public string EmailToValidate
        {
            get
            {
                return m_emailToValidate;
            }

            set
            {
                m_emailToValidate = value;
            }
        }

        private int m_requestTimeOut = 80000;
        public int RequestTimeOut
        {
            get
            {
                return m_requestTimeOut;
            }

            set
            {
                m_requestTimeOut = value;
            }
        }
        private int m_readTimeOut = 80000;
        public int ReadTimeOut
        {
            get
            {
                return m_readTimeOut;
            }

            set
            {
                m_readTimeOut = value;
            }
        }
        public ZeroBounceResultsModel ValidateEmail()
        {
            // secure SSL / TLS channel for different .Net versions
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            var apiUrl = "";

            if (IpAddress == "") apiUrl = "https://api.zerobounce.net/v1/validate?apikey=" + ApiKey + "&email=" + System.Net.WebUtility.UrlEncode(EmailToValidate);
            else apiUrl = "https://api.zerobounce.net/v1/validatewithip?apikey=" + ApiKey + "&email=" + System.Net.WebUtility.UrlEncode(EmailToValidate) + "&ipaddress=" + System.Net.WebUtility.UrlEncode(IpAddress);

            var responseString = "";
            var oResults = new ZeroBounceResultsModel();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(apiUrl);
            request.Timeout = RequestTimeOut;
            request.Method = "GET";
            Console.WriteLine("Input APIKey: " + ApiKey);
          
            var serializer = new JavaScriptSerializer();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    response.GetResponseStream().ReadTimeout = ReadTimeOut;
                    using (StreamReader ostream = new StreamReader(response.GetResponseStream()))
                    {
                        responseString = ostream.ReadToEnd();
                        oResults = serializer.Deserialize<ZeroBounceResultsModel>(responseString);                        
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("The operation has timed out")) oResults.sub_status = "timeout_exceeded";
                else oResults.sub_status = "exception_occurred";
                oResults.status = "Unknown";
                oResults.domain = EmailToValidate.Substring(EmailToValidate.IndexOf("@") + 1).ToLower();
                oResults.account = EmailToValidate.Substring(0, EmailToValidate.IndexOf("@")).ToLower();
                oResults.address = EmailToValidate.ToLower();

                Console.WriteLine(ex.ToString());
                oResults.errMsg = ex.ToString();
            }
            return oResults;
        }
        public ZeroBounceCreditsModel GetCredits()
        {
            // secure SSL / TLS channel for different .Net versions            
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            var apiUrl = "https://api.zerobounce.net/v1/getcredits?apikey=" + ApiKey;
            var responseString = "";
            var oResults = new ZeroBounceCreditsModel();

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(apiUrl);
            request.Timeout = RequestTimeOut;
            request.Method = "GET";           
            Console.WriteLine("APIKey: " + ApiKey);

            var serializer = new JavaScriptSerializer();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    response.GetResponseStream().ReadTimeout = ReadTimeOut;
                    using (StreamReader ostream = new StreamReader(response.GetResponseStream()))
                    {
                        responseString = ostream.ReadToEnd();
                        oResults = serializer.Deserialize<ZeroBounceCreditsModel>(responseString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                oResults.errMsg = ex.ToString();
            }
            return oResults;
        }
    }
}
