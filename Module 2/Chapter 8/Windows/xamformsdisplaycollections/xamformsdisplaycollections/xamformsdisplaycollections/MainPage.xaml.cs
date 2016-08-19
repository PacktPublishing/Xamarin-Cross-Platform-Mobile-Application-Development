using Xamarin.Forms;

namespace XamFormsDisplayCollections
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            Character character = args.Item as Character;
            await Navigation.PushAsync(new CharacterPage(character));
        }
    }
}
