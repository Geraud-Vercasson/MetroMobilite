using System.Windows.Controls;

namespace MetroApp.Views
{
    /// <summary>
    /// Logique d'interaction pour StationsView.xaml
    /// </summary>
    public partial class StationsView : UserControl
    {
        public StationsView()
        {
            InitializeComponent();
        }
    }
}

            //<ListBox HorizontalAlignment = "Left" Height="300" Margin="395,89,0,0" VerticalAlignment="Top" Width="375" ItemsSource="{Binding SelectedStation.lines}">
            //    <ListBox.ItemTemplate>
            //        <DataTemplate>
            //            <TextBlock Text = "{Binding name}" />
            //        </ DataTemplate >
            //    </ ListBox.ItemTemplate >
            //</ ListBox >