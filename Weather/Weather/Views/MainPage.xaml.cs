using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Views;
using Xamarin.Forms;

namespace Weather
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var src = new List<LocationWeatherInfo>();
            src.Add(new LocationWeatherInfo() {
                Location = new Location() { Key = "123", EnglishName = "Silent Hill", AdministrativeArea = new AdministrativeArea(), Country = new Country() { EnglishName = "US"} },
                WeatherConditions = new CurrentConditions() { WeatherText = "Foggy", Temperature = new Temperature() { Metric = new Metric(), Imperial = new Imperial() } }
            });
            //listView.ItemsSource = src;
            listView.ItemsSource = App.WeatherManager.ConditionsList;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            string keyToRemove = ((sender as Button).BindingContext as LocationWeatherInfo).Location.Key;
            App.WeatherManager.removeLocation(keyToRemove);
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            var searchLocationPage = new SearchLocationPage();
            await Navigation.PushAsync(searchLocationPage);
        }

        private void OnRefreshItemClicked(object sender, EventArgs e)
        {
            App.WeatherManager.LoadConditions();
        }
    }
}
