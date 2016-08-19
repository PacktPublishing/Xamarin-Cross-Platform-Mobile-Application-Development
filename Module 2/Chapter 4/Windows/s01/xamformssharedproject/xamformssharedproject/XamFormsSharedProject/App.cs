using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFormsSharedProject
{
    public class App : Application
	{
		public App ()
		{
            // The root page of your application

            Label label = new Label
            {
                XAlign = TextAlignment.Center
            };

            NameService nameService = new NameService();

            nameService.GetGreeting("Georgios", "Taskos")
                .ContinueWith((antecedent) =>
            {
                label.Text = antecedent.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						label
					}
				}
			};
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
