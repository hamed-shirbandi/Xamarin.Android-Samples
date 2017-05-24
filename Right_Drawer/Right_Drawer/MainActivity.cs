using Android.App;
using Android.Widget;
using Android.OS;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Content.PM;
using Android.Views;

namespace Right_Drawer
{
    [Activity(Label = "Right Drawer M1", Theme = "@style/Theme.DesignDemo", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayShowTitleEnabled(true);
        }



        /// <summary>
        /// /
        /// </summary>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionBar_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



        /// <summary>
        /// /
        /// </summary>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.End);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }




    }
}

