using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace ActionBar
{
    [Activity(Label = "ActionBar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            ActionBar.SetTitle(Resource.String.Custom_ActionBar_Name);

        }



        /// <summary>
        /// 
        /// </summary>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MyActionBar, menu);
            return base.OnCreateOptionsMenu(menu);
        }




        /// <summary>
        /// 
        /// </summary>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addnew:
                    Toast.MakeText(this, "add new clicked", ToastLength.Short).Show();
                    return true;

                case Resource.Id.cut:
                    MakeDialogAlert();
                    Toast.MakeText(this, "cut clicked", ToastLength.Short).Show();
                    return true;


            }
            return base.OnOptionsItemSelected(item);
        }





        /// <summary>
        /// 
        /// </summary>
        private void MakeDialogAlert()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("حذف آیتم");
            alert.SetMessage("آیا واقعا میخواهید این آیتم حذف شود؟");

            alert.SetPositiveButton("بله", (senderAlert, args) => {
                Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("خیر", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });

            alert.SetNeutralButton("نمیدونم", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }



    }
}
