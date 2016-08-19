using System;
using System.Collections.Generic;
using System.Text;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.Master.Fibonacci.iOS.Views
{
    //[Register("SingleCalculationView")]
    public partial class SingleCalculationView : MvxViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public SingleCalculationView(IntPtr handle)
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

            btnCalculate.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnCalculate.Layer.BorderWidth = (nfloat)1;
            btnCalculate.Layer.CornerRadius = 3;

            btnClose.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnClose.Layer.BorderWidth = (nfloat)1;
            btnClose.Layer.CornerRadius = 3;

            var set = this.CreateBindingSet<SingleCalculationView, Core.ViewModels.SingleCalculationViewModel>();
            set.Bind(btnCalculate).To(vm => vm.DoCalculateCommand);
            set.Bind(btnClose).To(vm => vm.CloseCommand);
            set.Bind(lblInfoText).To(vm => vm.InfoText);
            set.Bind(txtOrdinal).To(vm => vm.Input);
            set.Bind(txtResult).To(vm => vm.Result);
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
