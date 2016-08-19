using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsAcceptanceUITesting
{
	public partial class ContactPage : ContentPage
	{
		public ContactPage ()
		{
			InitializeComponent ();
		}

		private async void OnSaveClick(object sender, EventArgs args)
		{
			if (!string.IsNullOrWhiteSpace (nameEditText.Text) &&
			    !string.IsNullOrWhiteSpace (emailEditText.Text)) {
				await Navigation.PopAsync (true);
			}
		}
	}
}

