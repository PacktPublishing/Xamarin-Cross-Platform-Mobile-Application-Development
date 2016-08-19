using System;
using Xamarin.Forms;
using XamFormsREST.Models;

namespace XamFormsREST.Views
{
    public partial class OrderDetailsPage : ContentPage
    {
        private readonly DataService _dataService = new DataService();

        public OrderDetailsPage(Order order)
        {
            InitializeComponent();

            BindingContext = order;
        }

        private async void OnSaveUserClick(object sender, EventArgs e)
        {
            await _dataService.UpdateAsync((Order)BindingContext);
            await Navigation.PopAsync();
        }
    }
}
