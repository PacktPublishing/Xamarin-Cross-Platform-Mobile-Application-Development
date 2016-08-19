using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsTestCloud
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private async void OnDetailsClick(object sender, EventArgs args)
		{
			await Navigation.PushAsync (new DetailsPage ());
		}
	}
}

