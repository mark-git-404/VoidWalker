using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Autopick.Rift.Models
{

    public class Summoner
    {
        public int accountId { get; set; }
        public string displayName { get; set; }
        public string internalName { get; set; }
        public int percentCompleteForNextLevel { get; set; }
        public int profileIconId { get; set; }
        public string puuid { get; set; }
        public int summonerId { get; set; }
        public int summonerLevel { get; set; }
        public int xpSinceLastLevel { get; set; }
        public int xpUntilNextLevel { get; set; }
    }

}
