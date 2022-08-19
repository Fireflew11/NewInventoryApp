using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using static Android.Manifest;
using Android;

namespace NewInventoryApp
{
    [Activity(Label = "tusik", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btnNewShoe;
        EditText SearchCompany, SearchSize;
        readonly string[] permissionGroup =
       {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        public void OnClick(View v)
        {

            if (v == SearchSize)
            {
                SearchSize.SetTextColor(Android.Graphics.Color.Black);
            }

            if (v == SearchCompany)
            {
                SearchCompany.SetTextColor(Android.Graphics.Color.Black);
            }

            if (v == btnNewShoe)
            {
                Intent newShowIntent = new Intent(this, typeof(Activities.NewShoeActivity));
                StartActivity((newShowIntent));
            }




        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainScreen);


            SearchSize = (EditText)FindViewById(Resource.Id.SearchSize);
            SearchSize.SetOnClickListener(this);
            SearchCompany = (EditText)FindViewById(Resource.Id.SearchCompanyg);
            SearchCompany.SetOnClickListener(this);
            btnNewShoe = (Button)FindViewById(Resource.Id.BtnAddShoe);
            btnNewShoe.SetOnClickListener(this);

            RequestPermissions(permissionGroup, 0);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}