using System.Collections.Generic;
using System.Net;

namespace Transports
{
    class StationsProvider : IStationsProvider
    {
        private IMetroAPICall _metroAPICall;
        private string _urlWithouthEndPoint;
        private string _sLongitude, _sLatitude;
        private bool _details;

        public StationsProvider()
            : this(new MetroAPICall(), "5.7287321", "45.1856964", true)
        {

        }

        internal StationsProvider(IMetroAPICall metroAPICall, string sLongitude, string sLatitude, bool details)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _sLongitude = sLongitude;
            _sLatitude = sLatitude;
            _details = details;
            _metroAPICall = metroAPICall;
        }

        public void ChangePosition(string longitude, string latitude)
        {
            _sLongitude = longitude;
            _sLatitude = latitude;
        }

        public Dictionary<string, Station> GetStations(int dist)
        {
            List<Station> stationsList = GetStationsByDistance(dist);
            Dictionary<string, Station> stationsDict = new Dictionary<string, Station>();

            foreach (Station station in stationsList)
            {
                if (!stationsDict.ContainsKey(station.name))
                {
                    stationsDict.Add(station.name, station);
                }
                else
                {
                    for (int i = 0; i < station.lines.Count; i++)
                    {
                        if (!stationsDict[station.name].lines.Contains(station.lines[i]))
                        {
                            stationsDict[station.name].lines.Add(station.lines[i]);
                        }
                    }
                }
            }
            return stationsDict;
        }

        public List<Station> GetStationsByDistance(int dist)
        {
            _urlWithouthEndPoint = $"linesNear/json?x={_sLongitude}&y={_sLatitude}&dist={dist}&details={_details}";

            return _metroAPICall.Get<List<Station>>(_urlWithouthEndPoint);
        }
    }
}
