using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    class StationInfosProvider : IStationInfosProvider
    {
        private IStationsProvider _stationsProvider;
        private ILineProvider _lineProvider;

        public StationInfosProvider()
            : this(new StationsProvider(), new LineProvider())
        {

        }

        internal StationInfosProvider(IStationsProvider stationsProvider, ILineProvider lineProvider)
        {
            _stationsProvider = stationsProvider;
            _lineProvider = lineProvider;
        }

        public Dictionary<string, StationInfo> GetStationInfos(int dist)
        {
            Dictionary<string, StationInfo> myDict = new Dictionary<string, StationInfo>();

            Dictionary<string, Station> stationDict = _stationsProvider.GetStations(dist);

            List<string> sLines = new List<string>();

            foreach (KeyValuePair<string, Station> kvp in stationDict)
            {
                foreach (string sLine in kvp.Value.lines)
                {
                    if (!sLines.Contains(sLine))
                    {
                        sLines.Add(sLine);
                    }
                }
            }

            Dictionary<string, Line> lineDict = _lineProvider.getLines(sLines);

            foreach(KeyValuePair<string, Station> kvp in stationDict)
            {
                List<Line> lines = new List<Line>();

                foreach(string sLine in kvp.Value.lines)
                {
                    lines.Add(lineDict[sLine]);
                }

                myDict.Add(kvp.Key, new StationInfo(kvp.Value.id, kvp.Value.name, kvp.Value.lon, kvp.Value.lat, lines));
            }

            return myDict;
        }

        public void ChangePosition(string longitude, string latitude)
        {
            _stationsProvider.ChangePosition(longitude, latitude);
        }
    }
}
