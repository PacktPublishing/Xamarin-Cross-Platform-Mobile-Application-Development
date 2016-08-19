using System;
using Xamarin.Forms;

namespace XamFormsAuthenticateProviders
{
	public class ProvidersAuthPage : ContentPage
	{
		StackLayout stackLayout;
		Button facebookButton;
		Button googleButton;

		public ProvidersAuthPage ()
		{
			facebookButton = new Button {
				Text = "Facebook"
			};
			facebookButton.Clicked += async (sender, e) => 
				await Navigation.PushModalAsync(new LoginPage(Provider.Facebook));

			googleButton = new Button {
				Text = "Google"
			};
			googleButton.Clicked += async (sender, e) => 
				await Navigation.PushModalAsync(new LoginPage(Provider.Google));

			stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Children = {
					facebookButton,
					googleButton
				}
			};

			this.Content = stackLayout;
		}
	}
}