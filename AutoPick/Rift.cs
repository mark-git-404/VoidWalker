using Luna.Autopick.LCU;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Luna.Autopick.Rift
{
    class Rift
    {
        //Fields
        private LeagueClient LeagueClient;

        //Events
        public event Action OnReadyCheck;

        public Rift(LeagueClient leagueclient)
        {
            LeagueClient = leagueclient;
        }
        //Methods
        public string GetSummonerName()
        {
            string summoner =  Request<string>("/lol-summoner/v1/current-summoner", "GET");
            return summoner;
        }
        public void Check(string tipo)
            /// "accept" | "decline"
        {
            Request("/lol-matchmaking/v1/ready-check/" + tipo, "POST");
        }
        
        //Listeners
        public void ReadyCheckListen()
        {
            bool founded = false;
            while (!founded)
            {
                string searchState = Request<string>("/lol-matchmaking/v1/search", "GET");

                Thread.Sleep(5000);

                if(searchState == "Found")
                {

                    founded = true;    
                    OnReadyCheck?.Invoke();
                    
                }
            }
        }
        public void PickChampion()
        {

        }

        //Utils
        private T Request<T>(string endpoint, string method)
        {
            //nsole.WriteLine("Passou por aqui");
            var req = (HttpWebRequest)WebRequest.Create(LeagueClient.URL + endpoint);
            req.Method = method;
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(
                Encoding.Default.GetBytes(LeagueClient.Username + ":" + LeagueClient.AuthToken));
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            try
            {
                using (var response = req.GetResponse())
                {
                    
                    var streamData = response.GetResponseStream();
                    StreamReader reader = new StreamReader(streamData);
                    object objResponse = reader.ReadToEnd();
                    Console.ReadLine();
                    streamData.Close();
                    response.Close();
                    return (T)objResponse;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Deu erro");
                return default(T);
            }
        }
        private void Request(string endpoint, string method)
        {
            Console.WriteLine("Passou por aqui");
            var req = (HttpWebRequest)WebRequest.Create(LeagueClient.URL + endpoint);
            req.Method = method;
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(
                Encoding.Default.GetBytes(LeagueClient.Username + ":" + LeagueClient.AuthToken));
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            try
            {
                using (var response = req.GetResponse())
                {
                    var streamData = response.GetResponseStream();
                    StreamReader reader = new StreamReader(streamData);
                    object objResponse = reader.ReadToEnd();
                    Console.ReadLine();
                    streamData.Close();
                    response.Close();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Deu erro");
            }
        }


    }
    class RiftResponse
    {
        string Result { get; }

    }
}
