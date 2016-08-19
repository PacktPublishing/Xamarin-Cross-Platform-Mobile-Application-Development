using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using ViewCustomRenderer;
using ViewCustomRenderer.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ViewCustomRenderer.WinPhone
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                TextBox textBox = Control.Children[0] as TextBox;
                //textBox.Style = App.Current.Resources["TransparentTextBoxStyle"] as System.Windows.Style;
                textBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                textBox.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
