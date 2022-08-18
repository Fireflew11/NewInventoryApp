using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Plugin.Media;
using Android.Graphics;

namespace NewInventoryApp.Activities
{
    [Activity(Label = "NewShoeActivity")]
    public class NewShoeActivity : Activity, View.IOnClickListener
    {
        Button captureButton, uploadButton;
        ImageView imageView;

        
        public void OnClick(View v)
        {
            if(v == captureButton)
            {
                TakePhoto();
            }
            if(v == uploadButton)
            {

            }
        }

        async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 40,
                Name = "myImage.jpg",
                Directory = "sample"
            });

            if(file == null)
            {
                return;
            }

            //convert file to byte array and set the resulting bitmap to imageview
            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            imageView.SetImageBitmap(bitmap);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewShoeScreen);
            captureButton = FindViewById<Button>(Resource.Id.captureButton);
            captureButton.SetOnClickListener(this);
            uploadButton = FindViewById<Button>(Resource.Id.uploadButton);
            uploadButton.SetOnClickListener(this);
            imageView = FindViewById<ImageView>(Resource.Id.thisImageView);
            
        }
    }
}