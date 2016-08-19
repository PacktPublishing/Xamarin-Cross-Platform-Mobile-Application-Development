using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsAcceptanceUITesting
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private async void OnAddContactClick(object sender, EventArgs args)
		{
			await Navigation.PushAsync (new ContactPage ());
		}
	}
}

