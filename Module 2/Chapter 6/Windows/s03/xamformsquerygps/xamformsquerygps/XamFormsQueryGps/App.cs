using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFormsQueryGps
{
    public class App : Application
    {
        Label gpsLabel;

        public App()
        {
            IGeolocator locator = DependencyService.Get<IGeolocator>();
            locator.DesiredAccuracy = 50;
            locator.AllowsBackgroundUpdates = true;
            locator.StartListening(1, 1, true);
            locator.PositionChanged += LocatorPositionChanged;

            Button button = new Button
            {
                Text = "Get Position!"
            };
            button.Clicked += async (sender, e) => await GetCurrentLocationAsync(locator);
            gpsLabel = new Label
            {
                Text = "GPS Coordinates"
            };

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        gpsLabel,
                        button
                    }
                }
            };
        }

        async Task GetCurrentLocationAsync(IGeolocator locator)
        {
            Position position = await locator.GetPositionAsync(10000);
            PrintPosition(position);
        }

        private void LocatorPositionChanged(object sender, PositionEventArgs e)
        {
            PrintPosition(e.Position);
        }

        private void PrintPosition(Position position)
        {
            gpsLabel.Text = string.Format(
                "Time: {0} \n" +
                "Lat: {1} \n" +
                "Long: {2} \n " +
                "Altitude: {3} \n" +
                "Altitude Accuracy: {4} \n" +
                "Accuracy: {5} \n " +
                "Heading: {6} \n " +
                "Speed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy,
                position.Heading, position.Speed);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
