using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Auth;

namespace XamFormsAuthenticateProviders.WinPhone
{
    public partial class WebAuthenticatorPage : PhoneApplicationPage
    {
        public WebAuthenticatorPage()
        {
            InitializeComponent();

            this.browser.Navigating += OnBrowserNavigating;
            this.browser.Navigated += OnBrowserNavigated;
            this.browser.NavigationFailed += OnBrowserNavigationFailed;
        }

        private WebAuthenticator auth;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string key = NavigationContext.QueryString["key"];

            this.auth = (WebAuthenticator)PhoneApplicationService.Current.State[key];
            this.auth.Completed += (sender, args) => NavigationService.GoBack();
            this.auth.Error += OnAuthError;

            PhoneApplicationService.Current.State.Remove(key);

            if (this.auth.ClearCookiesBeforeLogin)
                await this.browser.ClearCookiesAsync();

            Uri uri = await this.auth.GetInitialUrlAsync();
            this.browser.Source = uri;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.auth.OnCancelled();
            base.OnNavigatedFrom(e);
        }

        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            //NavigationService.GoBack();
        }

        private void OnBrowserNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            this.progress.IsVisible = false;
            if (e.Exception == null)
                this.auth.OnError("Unknown"); // Shows up when not connected to the internet
            else
                this.auth.OnError(e.Exception);
        }

        private void OnBrowserNavigated(object sender, NavigationEventArgs e)
        {
            this.progress.IsVisible = false;
            this.auth.OnPageLoaded(e.Uri);
        }

        private void OnBrowserNavigating(object sender, NavigatingEventArgs e)
        {
            this.progress.IsVisible = true;
            this.auth.OnPageLoading(e.Uri);
        }
    }
}