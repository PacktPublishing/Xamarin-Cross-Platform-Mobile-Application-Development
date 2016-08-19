using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamFormsNativePages;
using XamFormsNativePages.Droid;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]

namespace XamFormsNativePages.Droid
{
    public class MainPageRenderer : PageRenderer
    {
        private Android.Widget.Button _button;
        private Android.Views.View _view;

        private MainPage Page
        {
            get { return Element as MainPage; }
        }

        public MainPageRenderer()
        {
            Activity activity = (Activity)Forms.Context;
            _view = activity.LayoutInflater.Inflate(Resource.Layout.MainDroidLayout, this, false);
            _button = _view.FindViewById<Android.Widget.Button>(Resource.Id.button);
            _button.Click += OnButtonClick;
            AddView(_view);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var oldPage = e.OldElement as MainPage;
            if (oldPage != null)
            {
                oldPage.PropertyChanged -= OnPagePropertyChanged;
            }

            var newPage = e.NewElement as MainPage;
            if (newPage != null)
            {
                newPage.PropertyChanged += OnPagePropertyChanged;
            }

            UpdateButtonText();
        }

        private void OnPagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == MainPage.RandomNumberProperty.PropertyName)
            {
                UpdateButtonText();
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            _view.Measure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(_view.MeasuredWidth, _view.MeasuredHeight);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            _view.Layout(l, t, r, b);
        }

        private void UpdateButtonText()
        {
            if (Page != null)
            {
                _button.Text = Page.RandomNumber.ToString();
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (Page != null)
            {
                Page.OnButtonPressed();
            }
        }
    }
}