using Xamarin.Forms;

namespace XamFormsCodeBinding
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Person person)
        {
            InitializeComponent();

            Binding firstNameBinding = new Binding
            {
                Path = "FirstName",
                Source = person
            };
            firstNameLabel.SetBinding(Label.TextProperty, firstNameBinding);

            Binding lastNameBinding = new Binding
            {
                Path = "LastName",
                Source = person
            };
            lastNameLabel.SetBinding(Label.TextProperty, lastNameBinding);
        }
    }
}
