using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Luna.Autopick.Models;

namespace Luna.Autopick
{
    class DDragonData
    {
        DDRoot champions { get; set; }
        
        public List<string> GetAllChampions()
        {
            WebRequest request = WebRequest.Create(
                "http://ddragon.leagueoflegends.com/cdn/10.16.1/data/en_US/champion.json");

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

    }
}
