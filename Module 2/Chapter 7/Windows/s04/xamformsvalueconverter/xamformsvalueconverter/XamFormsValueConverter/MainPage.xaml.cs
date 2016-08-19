using Xamarin.Forms;

namespace XamFormsValueConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Order order)
        {
            InitializeComponent();

            BindingContext = order;
        }
    }
}
