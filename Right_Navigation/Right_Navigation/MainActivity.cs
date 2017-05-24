using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Content.PM;


namespace Right_Navigation
{
    [Activity(Label = "Right Navigation", Theme = "@style/Theme.DesignDemo", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Create ActionBarDrawerToggle button and add it to the toolbar  
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.actionBar_menu);
            toolbar.MenuItemClick += Toolbar_MenuItemClick;
            //SetSupportActionBar(toolbar);

            //SupportActionBar.SetHomeButtonEnabled(false);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetDisplayShowTitleEnabled(true);


            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, null, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView); //Calling Function  
        }




        /// <summary>
        /// 
        /// </summary>
        private void Toolbar_MenuItemClick(object sender, V7Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.End);
                    break;
            }

        }




        /// <summary>
        /// 
        /// </summary>
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }




        ///// <summary>
        ///// /
        ///// </summary>
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.actionBar_menu, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}




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

            return false;
        }




    }
}

