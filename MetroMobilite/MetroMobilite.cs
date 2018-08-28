using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transports
{
    public class MetroMobilite
    {
        private IStationsProvider _stationsProvider;

        public MetroMobilite()
            :this(new StationsProvider())
        {
        }

        internal MetroMobilite(IStationsProvider stationsProvider)
        {
            _stationsProvider = stationsProvider;
        }

        public List<Station> GetStationsByDist(int dist)
        {
            return _stationsProvider.GetStationsByDistance(dist);
        }

        internal Dictionary<string, Station> GetStations(int dist)
        {
            return _stationsProvider.GetStations(dist);
        }
    }
}
