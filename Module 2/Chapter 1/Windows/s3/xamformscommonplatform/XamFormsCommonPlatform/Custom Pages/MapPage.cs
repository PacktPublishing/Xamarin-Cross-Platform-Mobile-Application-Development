using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamFormsCommonPlatform
{
	public class MapPage : ContentPage
	{
		Map map;
		StackLayout stackLayout;

		public MapPage ()
		{
			MapSpan span = MapSpan.FromCenterAndRadius (new Position (40.730599, -73.986581), Distance.FromMiles (0.4));

			map = new Map (span) {
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Position position = new Position(40.730599, -73.986581);
			Pin  pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = "New York",
				Address = "New York"
			};

			map.Pins.Add(pin);

			stackLayout = new StackLayout { 
				Spacing = 0, 
				Children = { 
					map 
				} 
			};

			Content = stackLayout;
		}
	}
}