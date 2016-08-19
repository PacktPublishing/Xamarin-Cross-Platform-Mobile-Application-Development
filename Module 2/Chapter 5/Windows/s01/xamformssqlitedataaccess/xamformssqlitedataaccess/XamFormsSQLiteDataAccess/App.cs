using Xamarin.Forms;
using System.Diagnostics;

namespace XamFormsSQLiteDataAccess
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            ISQLiteConnection connection = DependencyService.Get<ISQLiteConnection>();

			if (connection.GetConnection () != null) {
				Debug.WriteLine ("SQLite connection is ready!");
			}

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = connection.GetDataBasePath()
                        }
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
