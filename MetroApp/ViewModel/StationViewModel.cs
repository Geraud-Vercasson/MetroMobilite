using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MetroMobilite;

namespace MetroApp.ViewModel
{
    class StationViewModel : ICommand
    {
        private Mobilite mobi;
        private ObservableCollection<StationInfo> _stations = new ObservableCollection<StationInfo>();

        public event EventHandler CanExecuteChanged;

        public int dist { get; set; }
        //public string sDist { get => dist.ToString(); set => dist = Convert.ToInt32(value); }

        public StationViewModel()
        {
            mobi = new Mobilite();
            dist = 500;
        }

        public ObservableCollection<StationInfo> Stations{ get => _stations; set => _stations = value; }

        public StationInfo SelectedStation { get; set; }

        public void LoadStations(int dist)
        {
            Dictionary<string, StationInfo> stationDict = mobi.GetStationInfos(dist);

            Stations.Clear();

            stationDict.Values.ToList().ForEach(Stations.Add);

        }

        public void ChangePosition(string lon, string lat)
        {
            mobi.ChangePosition(lon, lat);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoadStations(dist);
        }
    }
}
