using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using Luna.Autopick.DDragon.Models;

namespace Luna.Autopick.DDragon
{
    class DDragon
    {
        public DDRoot champions { get; set; }
        
        public List<string> GetAllChampions()
        {
            string lastPatch = LastPatch();
            WebRequest request = WebRequest.Create(
                $"http://ddragon.leagueoflegends.com/cdn/{lastPatch}/data/en_US/champion.json");

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                champions = JsonConvert.DeserializeObject<DDRoot>(responseFromServer);

                List<string> championList = champions.Data.Keys.ToList<string>();

                return championList;
            }
        }

        public string LastPatch()
        {
            string requestString = RequestDDragon("/api/versions.json");
            string[] clientPathches = JsonConvert.DeserializeObject<string[]>(requestString);

            return clientPathches[0];
        }

        private string RequestDDragon(string endpoint)
        {
            WebRequest request = WebRequest.Create(
                $"http://ddragon.leagueoflegends.com{endpoint}");

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                return responseFromServer;
            }
        }   
    }
}
