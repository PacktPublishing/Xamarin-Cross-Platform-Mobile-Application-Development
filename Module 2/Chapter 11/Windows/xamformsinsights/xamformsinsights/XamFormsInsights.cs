using System;

using Xamarin.Forms;

namespace XamFormsInsights
{
	public class App : Application
	{
		public const string InsightsApiKey = @"468718e944a2c7a7383464657ba5af337fd34d7c";

		public App ()
		{
			// The root page of your application
			MainPage = new MainPage();
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

