using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFormsBahaviorTriggers.Triggers
{
    public class LengthValidationTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            bool isValid = sender.Text.Length > 6;
            sender.BackgroundColor = isValid ? Color.Yellow : Color.Red;
        }
    }
}
