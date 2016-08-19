using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsTestCloud
{
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage ()
		{
			InitializeComponent ();
		}

		private async void OnOkClick(object sender, EventArgs args)
		{
			await Navigation.PopAsync ();
		}
	}
}

