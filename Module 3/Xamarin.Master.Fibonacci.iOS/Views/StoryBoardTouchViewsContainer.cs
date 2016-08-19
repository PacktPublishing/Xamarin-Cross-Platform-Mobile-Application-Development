using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace Xamarin.Master.Fibonacci.iOS.Views
{
    public class StoryBoardTouchViewsContainer : MvxTouchViewsContainer
    {
        protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            UIStoryboard storyboard = null;

            try
            {
                storyboard = UIStoryboard.FromName(viewType.Name, null);
            }
            catch (Exception)
            {
                storyboard = UIStoryboard.FromName("MainView", null);
            }

            try
            {
                var controller = (IMvxTouchView) storyboard.InstantiateViewController(viewType.Name);
                return controller;
            }
            catch (Exception)
            {
                return base.CreateViewOfType(viewType, request);
            }
        }
    }
}