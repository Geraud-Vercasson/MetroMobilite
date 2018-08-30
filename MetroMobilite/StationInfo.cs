using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    public class StationInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public List<Line> lines { get; set; }

        override public string ToString()
        {
            string res = $"{name}\n({lat};{lon})\nLines:\n";
            foreach (Line line in lines)
            {
                res += $"{line.ToString()}\n";
            }

            return res;
        }

        public StationInfo(string id, string name, double lon, double lat, List<Line> lines)
        {
            this.id = id;
            this.name = name;
            this.lon = lon;
            this.lat = lat;
            this.lines = lines;
        }
    }
}
