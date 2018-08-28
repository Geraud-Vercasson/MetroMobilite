using System;
using System.Collections.Generic;

namespace Transports
{
    class Program
    {
        static void Main(string[] args)
        {

            int dist = 500;
            MetroMobilite metro = new MetroMobilite();

            List<Station> stations = metro.GetStationsByDist(dist);

            foreach (Station station in stations)
            {
                Console.WriteLine(station.ToString());
            }
            Console.ReadKey();
        }
    }
}
