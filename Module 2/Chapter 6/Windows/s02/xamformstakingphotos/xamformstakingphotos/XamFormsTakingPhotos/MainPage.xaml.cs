using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamFormsTakingPhotos
{
    public partial class MainPage : ContentPage
    {
        private readonly IMedia Media = DependencyService.Get<IMedia>();
        
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnTakePhotoButtonClicked(object sender, EventArgs args)
        {
            if (!Media.IsCameraAvailable || 
                !Media.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            MediaFile file = await Media.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file != null)
            {

                ImageSource imageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                imagePhoto.Source = imageSource;
                Debug.WriteLine("Photo File Path: {0}", file.Path);
                file.Dispose();
            }
        }

        async void OnTakeVideoButtonClicked(object sender, EventArgs args)
        {
            if (!Media.IsCameraAvailable ||
                !Media.IsTakeVideoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            MediaFile file = await Media.TakeVideoAsync(new StoreVideoOptions
            {
                Directory = "Sample",
                Name = "test.mp4"
            });

            if (file != null)
            {

                ImageSource imageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                Debug.WriteLine("Video File Path: {0}", file.Path);
                file.Dispose();
            }
        }
    }
}
