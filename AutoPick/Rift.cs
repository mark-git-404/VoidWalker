using Luna.Autopick.LCU;
using Luna.AutoPick.Rift.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Autopick.Rift
{
    class Rift
    {
        //Fields
        private LeagueClient LeagueClient;
        private HttpClient httpClient;
        //Events
        public event System.Action OnReadyCheck;

        public Rift(LeagueClient leagueclient)
        {
            LeagueClient = leagueclient;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //HTTP
            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(LeagueClient.URL);
            httpClient.DefaultRequestHeaders.Clear();
            //Auth
            httpClient.DefaultRequestHeaders.Add(
                "authorization",
                "Basic " + Convert.ToBase64String(
                Encoding.Default.GetBytes(LeagueClient.Username + ":" + LeagueClient.AuthToken)));

            Console.WriteLine(LeagueClient.Username);
            Console.WriteLine(LeagueClient.AuthToken);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        //Methods
        public bool PickChampion(int ChampionId)
        {
                bool success = false;
            try
            {
                string session_str = ClientRequest("/lol-champ-select/v1/session", RiftMethods.GET).Result;
                Session session = JsonConvert.DeserializeObject<Session>(session_str);

                int MyCellId = -1;

                Console.WriteLine(session.myTeam.Length);

                for (int s = 0; s < session.myTeam.Length; s++)
                {
                    bool found = false;

                    if (found == true)
                    {
                        break;
                    }

                    int summonerId = session.myTeam[s].summonerId;
                    Console.WriteLine(summonerId);


                    if (summonerId == 781367)
                    {
                        Console.WriteLine("------------------");
                        MyCellId = session.myTeam[s].cellId;
                        found = true;
                        Console.WriteLine("My Cell id is: " + MyCellId);
                    }

                }

                string PickEndpoint = $"/lol-champ-select/v1/session/actions/{MyCellId}";
                string Key = @"""championId""";
                string BodyJson = $"{Key}:{ChampionId}";
                try
                {
                    ClientRequest(PickEndpoint, RiftMethods.PATCH, "{" + BodyJson + "}");
                    success = true;
                    return success;
                }
                catch
                {
                    
                    return success;

                }


            }
            catch 
            {
                
                return success;

            }

        }

        //Utils
        public async Task<string> ClientRequest(string EndPoint, RiftMethods Method)
        {
            //Request Sem Params
            switch (Method)
            {
                case RiftMethods.GET:
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(EndPoint);
                        string output = "Nao retorna nada";
                        Console.WriteLine(response.StatusCode);

                        if (response.IsSuccessStatusCode)
                        {
                            output = await response.Content.ReadAsStringAsync();
                        }
                        return output;
                    }

                case RiftMethods.POST: //POST sem body
                    break;
            }
            return null;
        }
        public async Task<string> ClientRequest(string EndPoint, RiftMethods Method, string Body)
        {
            //Request Sem Params
            switch (Method)
            {
                case RiftMethods.PATCH:
                    var method = new HttpMethod("PATCH");
                    
                    Console.WriteLine(Body);
                    //var jsonString = JsonConvert.SerializeObject(Body);
                    //Console.WriteLine(jsonString);
                    var content = new StringContent(Body, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(method, LeagueClient.URL + EndPoint)
                    {
                        Content = content
                    };
                    Console.WriteLine("Headers: "+ request.Headers);
                    Console.WriteLine("Content: "+ request.Content);

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    Console.WriteLine("StatusCode: "+ response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        var output = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Pickado");
                        return output;
                    }
                    break;

                case RiftMethods.POST: //POST sem body
                    break;
            }
            return null;
        }


    }
    enum RiftMethods
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        PATCH = 4,
    }
}
