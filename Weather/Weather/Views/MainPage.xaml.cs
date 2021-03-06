﻿using System;
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
            listView.ItemsSource = App.WeatherManager.ConditionsList;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            string keyToRemove = ((sender as Button).BindingContext as LocationWeatherInfo).Location.Key;
            App.WeatherManager.RemoveLocation(keyToRemove);
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            var searchLocationPage = new SearchLocationPage();
            await Navigation.PushAsync(searchLocationPage);
        }

        private void OnRefreshItemClicked(object sender, EventArgs e)
        {
            activityIndicator.IsVisible = true;
            App.WeatherManager.LoadConditions();
            activityIndicator.IsVisible = false;
        }
    }
}
