using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFormsAddingRemovingItems
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Thread-safe option when modifying a collection from another thread.
            //BindingBase.EnableCollectionSynchronization(
            //    Character.Characters,
            //    null,
            //    (list, context, action, writeAccess) =>
            //    {
            //        lock (list)
            //        {
            //            action();
            //        }
            //    });
        }

        private void OnToolbarClick(object sender, EventArgs args)
        {
            if (Character.Characters.SingleOrDefault(p => p.Name.Equals("Anakin Skywalker")) == null)
            {
                // Thread-safe option when modifying a collection from another thread.
                //Device.BeginInvokeOnMainThread(() =>
                //{
                    Character.Characters.Add(new Character
                    {
                        Name = "Anakin Skywalker",
                        Species = "Human",
                        ImageUrl = "http://static.comicvine.com/uploads/original/11125/111250671/4775035-a1.jpg"
                    });
                //});
            }
        }

        private void OnDelete(object sender, EventArgs args)
        {
            MenuItem menuItem = sender as MenuItem;
            Character character = menuItem.BindingContext as Character;
            Character.Characters.Remove(character);
        }

        private async void OnRefreshing(object sender, EventArgs args)
        {
            ListView listView = sender as ListView;
            listView.IsRefreshing = true;
            // Code to refresh ...
            // Called on the UI thread.
            Debug.WriteLine("Refreshing!");
            await Task.Delay(2000);
            listView.IsRefreshing = false;
        }
    }
}
