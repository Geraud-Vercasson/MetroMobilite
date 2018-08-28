using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports
{
    public class Station
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public List<string> lines { get; set; }

        override public string ToString()
        {
            string res = $"{name}\n({lat};{lon})\nLines:\n";
            foreach(string line in lines)
            {
                res += $"{line}\n";
            }

            return res;
        }

        public Station(string id, string name, double lon, double lat, List<string> lines)
        {
            this.id = id;
            this.name = name;
            this.lon = lon;
            this.lat = lat;
            this.lines = lines;
        }
    }
}
