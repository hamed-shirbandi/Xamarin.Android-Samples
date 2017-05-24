using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Android.App.ActionBar;

namespace ActionBar_Tab
{
    [Activity(Label = "ActionBar_Tab", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity,ITabListener
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            //ActionBar.SetDisplayUseLogoEnabled(true);
            ActionBar.SetIcon(Resource.Drawable.Icon);

            var tab1 = ActionBar.NewTab();
            tab1.SetText(Resource.String.Tab1);
            tab1.SetIcon(Resource.Drawable.Icon);
            tab1.SetTabListener(this);
          
            var tab2 = ActionBar.NewTab();
            tab2.SetText(Resource.String.Tab2);
            tab2.SetIcon(Resource.Drawable.Icon);
            tab2.SetTabListener(this);



            var tab3 = ActionBar.NewTab();
            tab3.SetText(Resource.String.Tab3);
            tab3.SetIcon(Resource.Drawable.Icon);
            tab3.SetTabListener(this);



            var tab4 = ActionBar.NewTab();
            tab4.SetText(Resource.String.Tab4);
            tab4.SetIcon(Resource.Drawable.Icon);
            tab4.SetTabListener(this);



            ActionBar.AddTab(tab1);
            ActionBar.AddTab(tab2);
            ActionBar.AddTab(tab3);
            ActionBar.AddTab(tab4);

            SetContentView(Resource.Layout.Main);


        }




        public void OnTabReselected(Tab tab, FragmentTransaction ft)
        {
            var msg = "Reselected " + tab.TextFormatted;
            Toast.MakeText(this, msg, ToastLength.Short).Show();
        }

        public void OnTabSelected(Tab tab, FragmentTransaction ft)
        {
            var msg = "Selected " + tab.TextFormatted;
            Toast.MakeText(this, msg, ToastLength.Short).Show();

        }

        public void OnTabUnselected(Tab tab, FragmentTransaction ft)
        {
            var msg = "Unselected " + tab.TextFormatted;
            Toast.MakeText(this, msg, ToastLength.Short).Show();

        }
    }
}

