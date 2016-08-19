using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XamFormsLocalNotifications.WinPhone.Resources;
using Xamarin.Forms.Platform.WinPhone;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace XamFormsLocalNotifications.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            DependencyService.Register<LocalNotificationsImplementation>();
            LoadApplication(new XamFormsLocalNotifications.App());
        }
    }
}