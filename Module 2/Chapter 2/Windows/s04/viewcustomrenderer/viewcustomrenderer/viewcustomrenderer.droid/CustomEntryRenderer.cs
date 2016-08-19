using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ViewCustomRenderer;
using ViewCustomRenderer.Droid;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ViewCustomRenderer.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundDrawable(null);
            }
        }
    }
}