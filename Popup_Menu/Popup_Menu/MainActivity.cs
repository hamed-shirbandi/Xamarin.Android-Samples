using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace Popup_Menu
{
    [Activity(Label = "Popup_Menu", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btn_show_popup;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            btn_show_popup = FindViewById<Button>(Resource.Id.btn_show_popup);
        
            btn_show_popup.Click += Button_Click;
        }



 
        /// <summary>
        /// 
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            PopupMenu menu = new PopupMenu(this, btn_show_popup);
            menu.Inflate(Resource.Menu.pop_up_menu);

            menu.MenuItemClick += Menu_MenuItemClick;
            menu.DismissEvent += Menu_DismissEvent;
            //menu.MenuItemClick += (s1, arg1) => {
            //    Log.Info("PopupMenu", arg1.Item.TitleFormatted.ToString());

            //};
            //menu.DismissEvent += (s2, arg2) => {
            //    Log.Info("PopupMenu", "menu dismissed");
            //};

            menu.Show();

        }

        private void Menu_DismissEvent(object sender, PopupMenu.DismissEventArgs e)
        {
            Toast.MakeText(this, "menu dismissed", ToastLength.Short).Show();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Menu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.cut:
                    Toast.MakeText(this, "cut clicked", ToastLength.Short).Show();
                    break;
                case Resource.Id.addnew:
                    Toast.MakeText(this, "add clicked", ToastLength.Short).Show();
                    break;
            }
        }


    }
}

