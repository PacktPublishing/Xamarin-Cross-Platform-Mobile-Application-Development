using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XamFormsAuthenticateProviders;
using XamFormsAuthenticateProviders.iOS;
using Xamarin.Auth;

[assembly:ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XamFormsAuthenticateProviders.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		LoginPage page;
		bool loginInProgress;

		public LoginPageRenderer ()
		{
		}

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || 
				Element == null)
				return;

			page = e.NewElement as LoginPage;
		}

		public override async void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (page == null || 
				loginInProgress)
				return;

			loginInProgress = true;
			try
			{
				OAuth2Authenticator auth = new OAuth2Authenticator(
					page.ProviderOAuthSettings.ClientId, // your OAuth2 client id
					page.ProviderOAuthSettings.ClientSecret, // your OAuth2 client secret
					page.ProviderOAuthSettings.ScopesString, // scopes
					new Uri(page.ProviderOAuthSettings.AuthorizeUrl), // the scopes, delimited by the "+" symbol
					new Uri(page.ProviderOAuthSettings.RedirectUrl), // the redirect URL for the service
					new Uri(page.ProviderOAuthSettings.AccessTokenUrl)); 

				auth.AllowCancel = true;
				auth.ShowUIErrors = true;
				// If authorization succeeds or is canceled, .Completed will be fired.
				auth.Completed += async (sender, args) => {
					if (args.IsAuthenticated)
					{
						Console.WriteLine("Authenticated!");
					} else {
						Console.WriteLine("Canceled!");
					}
					await DismissViewControllerAsync (true);
					await page.Navigation.PopModalAsync();
					loginInProgress = false;
				};

				auth.Error += (sender, args) => 
				{
					Console.WriteLine("Authentication Error: {0}", args.Exception);
				};

				await PresentViewControllerAsync (auth.GetUI (), true);

			}
			catch(Exception ex) {
				Console.WriteLine (ex);
			}
		}
	}
}

