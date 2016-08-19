using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace FormsCookbook
{
	public class MainPage : ContentPage
	{
		Entry userNameEntry;
		Entry passwordEntry;
		Button loginButton;
		StackLayout stackLayout;

		public MainPage ()
		{
			userNameEntry = new Entry { Placeholder = "username" };
			passwordEntry = new Entry { 
				Placeholder = "password",
				IsPassword = true
			};
			loginButton = new Button { Text = "Login" };

			loginButton.Clicked += LoginButton_Clicked;

			this.Padding = new Thickness (20);

			stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Children = {
					userNameEntry,
					passwordEntry,
					loginButton
				}
			};

			this.Content = stackLayout;
		}

		void LoginButton_Clicked (object sender, EventArgs e)
		{
			Debug.WriteLine (string.Format("Username: {0} - Password: {1}", 
				userNameEntry.Text, passwordEntry.Text));
		}
	}
}

