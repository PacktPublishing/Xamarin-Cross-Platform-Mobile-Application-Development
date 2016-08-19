using System;
using Xamarin.Forms;
using XamFormsCRUDSQLite.Data;
using XamFormsCRUDSQLite.Models;

namespace XamFormsCRUDSQLite.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        private IRepository<Contact> _contactRepo;
        public ContactDetailPage(Contact contact)
        {
            InitializeComponent();

            BindingContext = contact;
            ISQLiteAsyncConnectionService connectionService = DependencyService.Get<ISQLiteAsyncConnectionService>();
            _contactRepo = new Repository<Contact>(connectionService);
        }

        private async void OnSaveContactClick(object sender, EventArgs e)
        {
            await _contactRepo.UpdateAsync((Contact)BindingContext);
            await Navigation.PopAsync();
        }
    }
}