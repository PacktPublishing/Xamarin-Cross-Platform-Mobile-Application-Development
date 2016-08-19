using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsReplTest
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private async void OnLogInClick(object sender, EventArgs args)
		{
			if (string.IsNullOrWhiteSpace (usernameEntry.Text) ||
			    string.IsNullOrWhiteSpace (passwordEntry.Text)) {
				await DisplayAlert ("Log In Error", "Username or password is empty!", "OK", "Cancel");
			} else {
				await DisplayAlert ("Log In", "Nice!", "OK", "Cancel");
			}
		}
	}
}

