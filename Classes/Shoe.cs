using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewInventoryApp.Classes
{
    class Shoe
    {
        ImageButton imageButton;
        string company;
        string position;
        int[] sizes;

        public Shoe(ImageButton imageButton, String company, string position, int[] sizes)
        {
            this.imageButton = imageButton;
            this.company = company;
            this.position = position;
            this.sizes = sizes;
        }
    }
}