using System;
using Xamarin.Forms;
using XamFormsAuthenticateProviders;
using XamFormsAuthenticateProviders.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Android.App;

[assembly:ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XamFormsAuthenticateProviders.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		LoginPage page;
		bool loginInProgress;

		public LoginPageRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || 
				Element == null)
				return;
			
			page = e.NewElement as LoginPage;

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
				auth.Completed += async (sender, args) => {
					if (args.IsAuthenticated)
					{
						Console.WriteLine("Authenticated!");
					} else {
						Console.WriteLine("Canceled!");
					} 
					await page.Navigation.PopAsync();
					loginInProgress = false;
				};

				auth.Error += (sender, args) => 
				{
					Console.WriteLine("Authentication Error: {0}", args.Exception);
				};

				var activity = Xamarin.Forms.Forms.Context as Activity;
				activity.StartActivity (auth.GetUI (Xamarin.Forms.Forms.Context));
			}
			catch(Exception ex) {
				Console.WriteLine (ex);
			}
		}
	}
}

