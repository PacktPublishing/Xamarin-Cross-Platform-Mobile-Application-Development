using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace XamFormsCommonPlatform
{
	public class MainPage : ContentPage
	{
		private Button openUriButton;
		private Button startTimerButton;
		private Button marshalUIThreadButton;
		private Button displayAlertButton;
		private Button displayActionSheetButton;
		private Button openMapButton;
		private StackLayout stackLayout;

		public MainPage ()
		{
			openUriButton = new Button {
				Text = "Open Xamarin Evolve"
			};
			startTimerButton = new Button {
				Text = "Start timer"
			};
			marshalUIThreadButton = new Button {
				Text = "Invoke on main thread"
			};
			displayAlertButton = new Button {
				Text = "Display an alert"
			};
			displayActionSheetButton = new Button {
				Text = "Display an ActionSheet"
			};
			openMapButton = new Button {
				Text = "Open platform map"
			};

			openUriButton.Clicked += OpenUriButton_Clicked;
			startTimerButton.Clicked += StartTimerButton_Clicked;
			marshalUIThreadButton.Clicked += MarshalUIThreadButton_Clicked;
			displayAlertButton.Clicked += DisplayAlertButton_Clicked;
			displayActionSheetButton.Clicked += DisplayActionSheetButton_Clicked;
			openMapButton.Clicked += OpenMapButton_Clicked;

			stackLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Padding = new Thickness(10),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					openUriButton,
					startTimerButton,
					marshalUIThreadButton,
					displayAlertButton,
					displayActionSheetButton,
					openMapButton
				}
			};

			Content = stackLayout;
		}
			
		void OpenMapButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushModalAsync (new MapPage ());
		}

	 	async void DisplayActionSheetButton_Clicked (object sender, EventArgs e)
		{
			string action = await DisplayActionSheet ("Simple ActionSheet", "Cancel", "Delete", new string[] { 
				"Action1",
				"Action2",
				"Action3",
			});

			Debug.WriteLine ("We tapped {0}", action);
		}

		async void DisplayAlertButton_Clicked (object sender, EventArgs e)
		{
			bool result = await DisplayAlert ("Simple Alert Dialog", "Sweet!", "OK", "Cancel");
			Debug.WriteLine ("Alert result: {0}", result ? "OK" : "Cancel");
		}

		void MarshalUIThreadButton_Clicked (object sender, EventArgs e)
		{
			Task.Run (async () => {
				for (int i = 0; i < 3; i++) {
					await Task.Delay(1000);
					Device.BeginInvokeOnMainThread (() => {
						marshalUIThreadButton.Text = string.Format("Invoke {0}", i);
					});
				}
			});
		}

		void StartTimerButton_Clicked (object sender, EventArgs e)
		{
			Device.StartTimer (new TimeSpan (0, 0, 1), () => {
				Debug.WriteLine("Timer Delegate Invoked");
				return true; // false if we want to cancel the timer.
			});
		}

		void OpenUriButton_Clicked (object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://xamarin.com/evolve"));
		}
	}
}

