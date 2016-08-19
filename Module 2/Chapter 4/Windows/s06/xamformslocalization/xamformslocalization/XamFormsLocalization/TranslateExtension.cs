using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace XamFormsLocalization
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInfo;
		const string ResourceId = "XamFormsLocalization.AppResources";

        public TranslateExtension()
        {
            cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Text))
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, cultureInfo);

            if (translation == null)
            {
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, cultureInfo.Name),
                    "Text");
            }
            return translation;
        }
    }
}
