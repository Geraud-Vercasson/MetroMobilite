using System.Collections.Generic;

namespace MetroMobilite
{
    internal interface IStationsProvider
    {
        List<Station> GetStationsByDistance(int dist);
        Dictionary<string, Station> GetStations(int dist);
        void ChangePosition(string longitude, string latitude);
    }
}
