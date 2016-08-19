using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XamFormsAddGrouping
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ObservableCollection<GroupingObservableCollection<string, Character>>(
                Character.Characters
                    .OrderBy(c => c.Name)
                    .GroupBy(c => c.Name[0].ToString(), c => c)
                    .Select(g => 
                        new GroupingObservableCollection<string, Character>(g.Key, g)));
        }
    }
}
