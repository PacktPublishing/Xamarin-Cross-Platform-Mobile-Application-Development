using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamFormsInsights
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private void OnUnhandledExceptionClick(object sender, EventArgs args)
		{
			int i = 0;
			var result = 1 / i;
		}

		private void OnHandledExceptionClick(object sender, EventArgs args)
		{
			try
			{
				string aString = null;
				aString.Equals("will_throw");
			}
			catch (NullReferenceException ex) {
				Xamarin.Insights.Report (ex, new Dictionary<string, string>
					{
						{ "userId", "user-id" }
					});
			}
		}
	}
}

