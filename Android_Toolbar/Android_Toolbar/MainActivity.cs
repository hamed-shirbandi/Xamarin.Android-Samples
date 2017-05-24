using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using Java.Interop;
using Android.Content.PM;
using Android.Support.Design.Widget;

namespace Android_Toolbar
{
 
    [Activity(Label = "Android_Toolbar", MainLauncher = true,ScreenOrientation =ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
      

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);


            var topToolbar = FindViewById<V7Toolbar>(Resource.Id.top_toolbar);
            SetSupportActionBar(topToolbar);
            SupportActionBar.Title = "Top AppCompat Toolbar";


            var bottomToolbar = FindViewById<V7Toolbar>(Resource.Id.bottom_toolbar);
            //bottomToolbar.Title = "Bottom AppCompat Toolbar";
            bottomToolbar.InflateMenu(Resource.Menu.Bottom_Menu_Bar);
            bottomToolbar.MenuItemClick += BottomToolbar_MenuItemClick;

        }



        /// <summary>
        /// 
        /// </summary>
        private void BottomToolbar_MenuItemClick(object sender, V7Toolbar.MenuItemClickEventArgs e)
        {
            Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();
        }

     

        /// <summary>
        /// 
        /// </summary>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Top_Menu_Bar, menu);

            return base.OnCreateOptionsMenu(menu);
        }





        /// <summary>
        /// 
        /// </summary>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            Toast.MakeText(this, "top toolbar tapped: " + item.TitleFormatted, ToastLength.Short).Show();

            return base.OnOptionsItemSelected(item);
        }






    }
}

