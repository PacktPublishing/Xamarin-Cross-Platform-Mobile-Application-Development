using Xamarin.Forms;

namespace XamFormsDisplayCollections
{
    public partial class CharacterPage : ContentPage
    {
        public CharacterPage(Character character)
        {
            InitializeComponent();

            BindingContext = character;
        }
    }
}
