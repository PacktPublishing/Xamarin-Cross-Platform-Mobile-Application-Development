using System;
using Xamarin.Forms;

namespace XamFormsAuthenticateProviders
{
	public class LoginPage : ContentPage
	{
		public OAuthSettings ProviderOAuthSettings { get; set; }

		public LoginPage (Provider provider)
		{
			ProviderOAuthSettings = ProviderManager.GetProviderOAuthSettings (provider);
		}
	}
}