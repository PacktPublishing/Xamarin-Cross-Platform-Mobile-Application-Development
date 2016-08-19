using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFormsEfficientNetworking.Models;

namespace XamFormsEfficientNetworking.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DataService _dataService = new DataService();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            RefreshAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //RandomOrdersHelper.InsertOrdersAsync(100); // Add some records to the remote database
        }
        
        private Task RefreshAsync()
        {
            int skip = BindingContext != null ? ((IEnumerable<Order>)BindingContext).Count() : 0;
            return _dataService.GetAllOrdersAsync(skip).ContinueWith((antecedent) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (BindingContext == null)
                    {
                        BindingContext = new ObservableCollection<Order>(antecedent.Result);
                    }
                    else
                    {
                        foreach (Order item in antecedent.Result)
                        {
                            ((ObservableCollection<Order>)BindingContext).Add(item);
                        }
                    }
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}