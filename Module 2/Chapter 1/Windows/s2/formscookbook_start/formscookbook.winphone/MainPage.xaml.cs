using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace FormsCookbook.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new FormsCookbook.App());
        }
    }
}