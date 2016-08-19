using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsCookbook
{
	public class App : Application
	{
		public App ()
		{
			var userNameEntry = new Entry { Placeholder = "username" };
			var passwordEntry = new Entry { 
				Placeholder = "password",
				IsPassword = true
			};
			var loginButton = new Button { Text = "Login" };

			loginButton.Clicked += (sender, e) => {
				Debug.WriteLine (string.Format("Username: {0} - Password: {1}", 
					userNameEntry.Text, passwordEntry.Text));
			};

			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						userNameEntry,
						passwordEntry,
						loginButton
					}
				}
			};
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

