using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Autopick.Models
{
    class DDRoot
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
      
    }
    class Champion
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        
    }
}
