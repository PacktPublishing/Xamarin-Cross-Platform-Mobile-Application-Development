using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsAuthenticateProviders;
using XamFormsAuthenticateProviders.WinPhone;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginWebPage))]
namespace XamFormsAuthenticateProviders.WinPhone
{
    public partial class LoginWebPage : NavigationPageRenderer
    {
        public LoginWebPage()
        {
            InitializeComponent();
        }
    }
}