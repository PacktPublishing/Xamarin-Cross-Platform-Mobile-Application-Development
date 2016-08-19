using Plugin.LocalNotifications.Abstractions;
using Xamarin.Forms;

namespace XamFormsLocalNotifications
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            ILocalNotifications localNotifications = DependencyService.Get<ILocalNotifications>();

            Button showNotificationButton = new Button();
            showNotificationButton.Text = "Show Local Notification";
            showNotificationButton.Clicked += (sender, e) => localNotifications.Show("Test", "Local notification alert", 1);

            Button cancelNotificationButton = new Button();
            cancelNotificationButton.Text = "Cancel Local Notification";
            cancelNotificationButton.Clicked += (sender, e) => localNotifications.Cancel(1);

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        showNotificationButton,
                        cancelNotificationButton
                    }
                }
            };
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
