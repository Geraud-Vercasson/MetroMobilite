using MetroMobilite;
using System;
using System.Collections.Generic;

namespace Transports
{
    class Program
    {
        static void Main(string[] args)
        {

            int dist = 500;
            Mobilite metro = new Mobilite();

            Dictionary<string, StationInfo> stations = metro.GetStationInfos(dist);

            foreach (StationInfo stationInfo in stations.Values)
            {
                Console.WriteLine(stationInfo.ToString());
            }

            Console.ReadKey();
        }
    }
}
