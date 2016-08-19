using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.Master.Fibonacci.iOS.Views
{
    //[Register("RangeCalculationView")]
    public partial class RangeCalculationView : MvxViewController
    {
        private static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public RangeCalculationView(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();
            }
            catch (System.Exception ex)
            {
            }

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
                EdgesForExtendedLayout = UIRectEdge.Top;
            }

            btnCalculate.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnCalculate.Layer.BorderWidth = (nfloat)1;
            btnCalculate.Layer.CornerRadius = 3;

            btnClose.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnClose.Layer.BorderWidth = (nfloat)1;
            btnClose.Layer.CornerRadius = 3;

            //var lblInfoText = new UILabel(new CGRect(20, 70, 300, 40));
            //lblInfoText.TextColor = UIColor.Black;
            //Add(lblInfoText);

            //var lblOrdinal1 = new UILabel(new CGRect(20, 110, 300, 40));
            //lblOrdinal1.TextColor = UIColor.Black;
            //lblOrdinal1.Text = "Enter First Ordinal to Calculate";
            //Add(lblOrdinal1);

            //var txtOrdinal1 = new UITextField(new CGRect(20, 150, 300, 40));
            //txtOrdinal1.TextColor = UIColor.Black;
            //Add(txtOrdinal1);

            //var lblOrdinal2 = new UILabel(new CGRect(20, 190, 300, 40));
            //lblOrdinal2.TextColor = UIColor.Black;
            //lblOrdinal2.Text = "Enter Second Ordinal to Calculate";
            //Add(lblOrdinal2);

            //var txtOrdinal2 = new UITextField(new CGRect(20, 230, 300, 40));
            //txtOrdinal2.TextColor = UIColor.Black;
            //Add(txtOrdinal2);

            //var buttonCalculate = new UIButton(new CGRect(20, 270, 300, 40));
            //buttonCalculate.SetTitle("Calculate", UIControlState.Normal);
            //buttonCalculate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            //buttonCalculate.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            //Add(buttonCalculate);

            //var lblResult = new UILabel(new CGRect(20, 310, 300, 40));
            //lblResult.TextColor = UIColor.Black;
            //lblResult.Text = "Result";
            //Add(lblResult);

            //var txtResult = new UITextField(new CGRect(20, 350, 300, 40));
            //txtResult.TextColor = UIColor.Black;
            //Add(txtResult);

            //var buttonClose = new UIButton(new CGRect(20, 390, 300, 40));
            //buttonClose.SetTitle("Close", UIControlState.Normal);
            //buttonClose.SetTitleColor(UIColor.Black, UIControlState.Normal);
            //buttonClose.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            //Add(buttonClose);

            var set = this.CreateBindingSet<RangeCalculationView, Core.ViewModels.RangeCalculationViewModel>();
            set.Bind(btnCalculate).To(vm => vm.DoCalculateCommand);
            set.Bind(btnClose).To(vm => vm.CloseCommand);
            set.Bind(lblInfoText).To(vm => vm.InfoText);
            set.Bind(txtOrdinal1).To(vm => vm.Input1);
            set.Bind(txtOrdinal2).To(vm => vm.Input2);
            set.Bind(txtResult).To(vm => vm.Result);
            set.Bind(prgCalculation).For(v => v.Progress).To(vm => vm.Progress);
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }
    }
}
