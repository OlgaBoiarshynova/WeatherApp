using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
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

            var src = new List<CurrentConditions>();
            src.Add(new CurrentConditions());

            listView.ItemsSource = src;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            Console.WriteLine(e);
        }
    }
}
