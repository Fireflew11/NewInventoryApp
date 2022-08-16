using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace NewInventoryApp
{
    [Activity(Label = "tusik", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btnSize, btnCompany;

        public void OnClick(View v)
        {

            if(v == btnSize)
            {
                btnSize.SetTextColor(Android.Graphics.Color.Black);
                Intent intentEasy = new Intent(this, typeof(CompanyActivity));
•               //intentEasy.PutExtra(Constants.GAME_COLS_KEY, 7);
•               //intentEasy.PutExtra(Constants.GAME_ROWS_KEY, 14);
•               StartActivity(intentEasy);
            }

            if (v == btnCompany)
            {
                btnSize.SetTextColor(Android.Graphics.Color.Black);
            }




        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainScreen);


            btnSize = (Button)FindViewById(Resource.Id.mispar1);
            btnSize.SetOnClickListener(this);
            btnCompany = (Button)FindViewById(Resource.Id.mispar2);
            btnCompany.SetOnClickListener(this);


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}