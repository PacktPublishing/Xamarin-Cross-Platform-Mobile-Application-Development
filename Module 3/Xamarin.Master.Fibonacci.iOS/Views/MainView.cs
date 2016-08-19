
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AVFoundation;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Foundation;
using MobileCoreServices;
using ObjCRuntime;
using UIKit;
using Xamarin.Master.Fibonacci.Core;

namespace Xamarin.Master.Fibonacci.iOS.Views
{
    public partial class MainView : MvxViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public MainView(IntPtr handle) : base(handle)
        {
        }





        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSingleCalculation.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnSingleCalculation.Layer.BorderWidth = (nfloat)1;
            btnSingleCalculation.Layer.CornerRadius = 3;

            btnRangeCalculation.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnRangeCalculation.Layer.BorderWidth = (nfloat)1;
            btnRangeCalculation.Layer.CornerRadius = 3;

            btnGCCollect.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnGCCollect.Layer.BorderWidth = (nfloat)1;
            btnGCCollect.Layer.CornerRadius = 3;

            // Perform any additional setup after loading the view, typically from a nib.

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(btnSingleCalculation).To(vm => vm.NavigateToSingleCalculationCommand);
            set.Bind(btnRangeCalculation).To(vm => vm.NavigateToRangeCalculationCommand);
            set.Bind(btnGCCollect).To(vm => vm.GarbageCollectCommand);
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

        #endregion
    }
}