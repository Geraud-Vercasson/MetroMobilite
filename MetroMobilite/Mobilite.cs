using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    public class Mobilite
    {
        private IStationsProvider _stationsProvider;
        private IStationInfosProvider _stationInfosProvider;

        public Mobilite()
            :this(new StationsProvider(), new StationInfosProvider())
        {
        }

        internal Mobilite(IStationsProvider stationsProvider, IStationInfosProvider stationInfosProvider)
        {
            _stationsProvider = stationsProvider;
            _stationInfosProvider = stationInfosProvider;
        }

        public List<Station> GetStationsByDist(int dist)
        {
            return _stationsProvider.GetStationsByDistance(dist);
        }

        public Dictionary<string, Station> GetStations(int dist)
        {
            return _stationsProvider.GetStations(dist);
        }

        public Dictionary<string, StationInfo> GetStationInfos(int dist)
        {
            return _stationInfosProvider.GetStationInfos(dist);
        }

        public void ChangePosition(string longitude, string latitude)
        {
            _stationsProvider.ChangePosition(longitude, latitude);
            _stationInfosProvider.ChangePosition(longitude, latitude);
        }
    }
}
