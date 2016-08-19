using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFormsCRUDSQLite.Data;
using XamFormsCRUDSQLite.Models;

namespace XamFormsCRUDSQLite.Views
{
    public partial class MainPage : ContentPage
    {
        private IRepository<Contact> _contactRepo;

        public MainPage()
        {
            InitializeComponent();

            ISQLiteAsyncConnectionService connectionService = DependencyService.Get<ISQLiteAsyncConnectionService>();
            _contactRepo = new Repository<Contact>(connectionService);
        }

        private async void OnAddContactClick(object sender, EventArgs e)
        {
            await _contactRepo.InsertAsync(new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName: " + new Random().Next(10),
                LastName = "LastName: " + new Random().Next(10)
            });
            await RefreshAsync();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new ContactDetailPage((Contact)e.SelectedItem));
        }

        public async void OnCellClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Guid id = (Guid) button.CommandParameter;
            await _contactRepo.DeleteAsync(((List<Contact>)BindingContext).FirstOrDefault(p => p.Id == id));
            await RefreshAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            BindingContext = await _contactRepo.GetAllAsync();
        }
    }
}
