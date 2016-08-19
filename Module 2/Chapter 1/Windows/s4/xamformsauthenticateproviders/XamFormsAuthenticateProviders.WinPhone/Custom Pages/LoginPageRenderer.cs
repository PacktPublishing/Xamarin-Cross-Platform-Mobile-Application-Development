using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsAuthenticateProviders;
using XamFormsAuthenticateProviders.WinPhone.Custom_Pages;
using Button = Xamarin.Forms.Button;
using Page = Xamarin.Forms.Page;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XamFormsAuthenticateProviders.WinPhone.Custom_Pages
{
    public class LoginPageRenderer : PageRenderer
    {
        LoginPage page;
        bool loginInProgress;
        private WebView webView;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

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
                // If authorization succeeds or is canceled, .Completed will be fired.
                auth.Completed += async (sender, args) =>
                {
                    if (args.IsAuthenticated)
                    {
                        Console.WriteLine("Authenticated!");
                    }
                    else
                    {
                        Console.WriteLine("Canceled!");
                    }
                    await page.Navigation.PopAsync();
                    loginInProgress = false;
                };

                auth.Error += (sender, args) =>
                {
                    Console.WriteLine("Authentication Error: {0}", args.Exception);
                };

                //string url = auth.GetUI().AbsolutePath;
                auth.GetUI();
                Uri uri = auth.GetUI();
                WebBrowser browser = new WebBrowser
                {
                    Source = new Uri("http://www.xplatsolutions.com", UriKind.Absolute),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = Double.NaN,
                    Width = Double.NaN,
                    IsScriptEnabled = true,
                    Visibility = Visibility.Visible
                };

                StackPanel stackPanel1 = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                TextBlock printTextBlock = new TextBlock();
                printTextBlock.Text = "Hello, World!";
                stackPanel1.Children.Add(printTextBlock);
                stackPanel1.Children.Add(browser);
                TextBlock printTextBlock2 = new TextBlock();
                printTextBlock2.Text = "Hello, World2!";
                stackPanel1.Children.Add(printTextBlock2);
                Children.Add(stackPanel1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WebViewOnNavigated(object sender, WebNavigatedEventArgs webNavigatedEventArgs)
        {
            Debug.WriteLine("Navigated: {0}", webNavigatedEventArgs.Url);
        }

        private string OAuthURL(Provider provider)
        {
            string url = string.Empty;

            switch (provider)
            {
                case Provider.Facebook:
                    url = string.Format("{0}?scope=openid&client_id={1}&response_type=token&redirect_uri={2}",
                        page.ProviderOAuthSettings.AuthorizeUrl, page.ProviderOAuthSettings.ClientId,
                        page.ProviderOAuthSettings.RedirectUrl);
                    break;
                case Provider.Google:
                    break;
            }

            return url;
        }
    }
}
