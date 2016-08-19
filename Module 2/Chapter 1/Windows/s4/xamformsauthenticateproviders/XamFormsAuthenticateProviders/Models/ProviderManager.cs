using System;
using System.Collections.Generic;

namespace XamFormsAuthenticateProviders
{
	public enum Provider
	{
		Unknown = 0,
		Facebook,
		Google
	}

	public static class ProviderManager
	{
		private static OAuthSettings FacebookOAuthSettings 
		{ 
			get {
				return new OAuthSettings {
					ClientId = "935210496550457",
					ClientSecret = "d5ec17238e90b3f37ecb3fff794ddf12",
					AuthorizeUrl = "https://m.facebook.com/dialog/oauth/",
					RedirectUrl = "http://www.facebook.com/connect/login_success.html",
					AccessTokenUrl = "https://graph.facebook.com/v2.3/oauth/access_token",
					Scopes = new List<string> {
						""
					}
				};
			}
		}

		private static OAuthSettings GoogleOAuthSettings 
		{ 
			get {
				return new OAuthSettings {
					ClientId = "640732017405-1lt8rc2g01qlf83a6c08afsbu488li7g.apps.googleusercontent.com",
					ClientSecret = "KlDkvUTwDwiscyUen3HS8xN5",
					AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth",
					RedirectUrl = "https://www.googleapis.com/plus/v1/people/me",
					AccessTokenUrl = "https://accounts.google.com/o/oauth2/token",
					Scopes = new List<string> {
						"openid"
					}
				};
			}
		}

		public static OAuthSettings GetProviderOAuthSettings(Provider provider)
		{
			switch (provider) {
				case Provider.Facebook: {
					return FacebookOAuthSettings;
				}
				case Provider.Google: {
					return GoogleOAuthSettings;
				}
			}
			return new OAuthSettings();
		}
	}
}

