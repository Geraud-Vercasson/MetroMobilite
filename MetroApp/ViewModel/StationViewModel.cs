using System.Collections.Generic;
using System.Collections.ObjectModel;
using MetroMobilite;

namespace MetroApp.ViewModel
{
    class StationViewModel
    {
        private Mobilite mobi; 

        public StationViewModel() {
            mobi = new Mobilite();
            LoadStations();
        }

        public ObservableCollection<StationInfo> Stations { get; set; }

        public void LoadStations(int dist = 500)
        {
            Dictionary<string, StationInfo> stationDict = mobi.GetStationInfos(dist);

            Stations = new ObservableCollection<StationInfo>(stationDict.Values);
        }

        public void ChangePosition(string lon, string lat)
        {
            mobi.ChangePosition(lon, lat);
        }
    }
}
