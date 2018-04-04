using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Weather.Models;
using Windows.UI.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchLocationPage : ContentPage
    {
        public ObservableCollection<Location> Items { get; set; }
        public ICommand AddLocationCommand { get; private set; }

        public SearchLocationPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Items = new ObservableCollection<Location>();
			locationsListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            App.WeatherManager.addLocation(e.Item as Location);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void OnSearchRequested(object sender, EventArgs e)
        {
            locationsListView.ItemsSource = await App.WeatherManager.GetLocations(searchBar.Text);
        }
    }
}
