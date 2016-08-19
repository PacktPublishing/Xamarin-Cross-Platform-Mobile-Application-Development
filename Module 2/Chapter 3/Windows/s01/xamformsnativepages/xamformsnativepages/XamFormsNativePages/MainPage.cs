using System;
using Xamarin.Forms;

namespace XamFormsNativePages
{
	public class MainPage : Page
	{
		public static readonly BindableProperty RandomNumberProperty =
			BindableProperty.Create("RandomNumber", typeof(int), typeof(MainPage), 0);

		public int RandomNumber
		{
			get { return (int)GetValue(RandomNumberProperty); }
			set { SetValue(RandomNumberProperty, value); }
		}

		public event EventHandler ButtonPressed;

		public void OnButtonPressed()
		{
			if (ButtonPressed != null)
			{
				ButtonPressed(this, EventArgs.Empty);
			}
		}
	}
}

