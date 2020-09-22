using Luna.Autopick.DDragon.Models;
using Luna.Autopick.LCU;
using Luna.Autopick.Rift.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Autopick.Rift
{
    enum RiftMethods
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        PATCH = 4,
    }
    class Rift
    {
        //Properties
        public Summoner Summoner { get => _summoners; }

        //Fields
        private LeagueClient _lolClient;
        private HttpClient httpClient;
        private Summoner _summoners;
        
        //Events
        public event System.Action OnReadyCheck;
        public event System.Action OnChatConnected;

        public Rift(LeagueClient leagueclient)
        {
            _lolClient = leagueclient;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //HTTP
            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_lolClient.URL);
            httpClient.DefaultRequestHeaders.Clear();
            //Auth
            httpClient.DefaultRequestHeaders.Add(
                "authorization",
                "Basic " + Convert.ToBase64String(
                Encoding.Default.GetBytes(_lolClient.Username + ":" + _lolClient.AuthToken)));

            //Console.WriteLine(_lolClient.Username);
            //Console.WriteLine(_lolClient.AuthToken);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        //Methods
        public bool PickChampion(Champion champion)
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
                string BodyJson = $"{Key}:{champion.Key}";
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
        public Summoner GetSummoner()
        {
            try
            {
                //Console.WriteLine(_lolClient.URL);
                Summoner outputSummoner = new Summoner();
                string summonerRes = ClientRequest("/lol-summoner/v1/current-summoner", RiftMethods.GET).Result;
                //Console.WriteLine(summonerRes);

                outputSummoner = JsonConvert.DeserializeObject<Summoner>(summonerRes);

                //Console.WriteLine(outputSummoner.displayName);

                _summoners = outputSummoner;
                return outputSummoner;
            }
            catch
            {
                return null;
            }

        }
        
        //Utils
        //Get,Post, Put with no Body
        public async Task<string> ClientRequest(string EndPoint, RiftMethods Method)
        {
            //Request Sem Params
            switch (Method)
            {
                case RiftMethods.GET:
                    {
                        Uri uri = new Uri(_lolClient.URL + EndPoint);
                        HttpResponseMessage response = await httpClient.GetAsync(uri);

                        string output = null;
                        //Console.WriteLine(response.StatusCode);

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
    
        //Get,Post, Put with Body
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

                    var request = new HttpRequestMessage(method, _lolClient.URL + EndPoint)
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
    
}
