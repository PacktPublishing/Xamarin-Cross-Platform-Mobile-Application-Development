using Xamarin.Forms;

namespace XamFormsBindingModes
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Person person)
        {
            InitializeComponent();

            BindingContext = person;
        }
    }
}
