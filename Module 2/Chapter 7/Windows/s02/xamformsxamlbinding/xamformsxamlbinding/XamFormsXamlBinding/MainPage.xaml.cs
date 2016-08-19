using Xamarin.Forms;

namespace XamFormsXamlBinding
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
