using System;
using System.Collections.Generic;
using System.Linq;

namespace XamFormsAuthenticateProviders
{
	public class OAuthSettings
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string AuthorizeUrl { get; set; }
		public string RedirectUrl { get; set; }
		public string AccessTokenUrl { get; set; }
		public List<string> Scopes { get; set; }
		public string ScopesString {
			get {
				return Scopes.Aggregate((current, next) => string.Format("{0}+{1}", current, next));
			}
		}

		public OAuthSettings ()
		{
			Scopes = new List<string> ();
		}
	}
}

