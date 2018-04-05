using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Data;
using Xamarin.Forms;

namespace Weather
{
	public partial class App : Application
	{
        public static AccuWeatherManager WeatherManager { get; private set; }

        public App ()
		{
			InitializeComponent();

            WeatherManager = new AccuWeatherManager(new AccuWeatherService());

			MainPage = new NavigationPage(new Weather.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
