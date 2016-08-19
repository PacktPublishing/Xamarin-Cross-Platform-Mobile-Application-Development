using Xamarin.Forms;
using XamFormsMVVM.ViewModels;
using XamFormsMVVM.Views;
using XLabs.Forms.Mvvm;

namespace XamFormsMVVM
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            RegisterViews();
            MainPage = new NavigationPage((ContentPage)ViewFactory.CreatePage<ContactListViewModel, ContactListPage>());
        }

        private void RegisterViews()
        {
            ViewFactory.Register<ContactListPage, ContactListViewModel>();
            ViewFactory.Register<ContactDetailsPage, ContactDetailsViewModel>();
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
