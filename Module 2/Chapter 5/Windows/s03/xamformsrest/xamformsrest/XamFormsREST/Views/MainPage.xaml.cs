using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFormsREST.Models;

namespace XamFormsREST.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DataService _dataService = new DataService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddUserClick(object sender, EventArgs e)
        {
            await _dataService.InsertAsync(new Order
            {
                OrderNumber = new Random().Next(100).ToString()
            });
            await RefreshAsync();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new OrderDetailsPage((Order)e.SelectedItem));
        }

        public async void OnCellClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string id = (string)button.CommandParameter;
            await _dataService.DeleteAsync(((List<Order>)BindingContext).FirstOrDefault(p => p.ObjectId == id).ObjectId);
            await RefreshAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            BindingContext = await _dataService.GetAllAsync();
        }
    }
}
