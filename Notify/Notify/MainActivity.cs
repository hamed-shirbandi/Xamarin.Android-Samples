using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Media;

namespace Notify
{
    [Activity(Label = "Notify", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        const int notyId = 0;
        Notification.Builder notyBuilder;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button btn_edit = FindViewById<Button>(Resource.Id.btn_edit);
            Button btn_intent = FindViewById<Button>(Resource.Id.btn_intent);

            button.Click += Button_Click;
            btn_edit.Click += Btn_edit_Click;
            btn_intent.Click += Btn_intent_Click;
        }



        private void Btn_intent_Click(object sender, EventArgs e)
        {
            notyBuilder = new Notification.Builder(this);

            notyBuilder.SetContentTitle("عنوان پیام");
            notyBuilder.SetContentText("متن پیام در اینجا قرار میگیرد");
            notyBuilder.SetSmallIcon(Resource.Drawable.noty_small_icon);
            notyBuilder.SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.noty_large_icon));
            notyBuilder.SetAutoCancel(true);
     
            Intent intent = new Intent(this, typeof(MainActivity));
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.NoCreate);
            notyBuilder.SetContentIntent(pendingIntent);


            var notification = notyBuilder.Build();
            var notyManager = GetSystemService(Context.NotificationService) as NotificationManager;
            notyManager.Notify(notyId, notification);
        }






        private void Button_Click(object sender, EventArgs e)
        {
            notyBuilder = new Notification.Builder(this);

            notyBuilder.SetContentTitle("عنوان پیام");
            notyBuilder.SetContentText("متن پیام در اینجا قرار میگیرد");
            notyBuilder.SetSmallIcon(Resource.Drawable.noty_small_icon);
            notyBuilder.SetLargeIcon(BitmapFactory.DecodeResource(Resources,Resource.Drawable.noty_large_icon));
            notyBuilder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());
            notyBuilder.SetDefaults(NotificationDefaults.Sound|NotificationDefaults.Vibrate);
            notyBuilder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));
            notyBuilder.SetAutoCancel(true);
            notyBuilder.SetPriority((int)NotificationPriority.High);

            if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
            {
                notyBuilder.SetVisibility(NotificationVisibility.Public);
                notyBuilder.SetCategory(Notification.CategoryEmail);

            }



            #region BigTextStyle

            Notification.BigTextStyle textStyle = new Notification.BigTextStyle();
            string longTextMessage = "I went up one pair of stairs.";
            longTextMessage += " / Just like me. ";
            textStyle.BigText(longTextMessage);
            textStyle.SetSummaryText("The summary text goes here.");
            //notyBuilder.SetStyle(textStyle);

            #endregion

            #region InboxStyle

            var inboxStyle = new Notification.InboxStyle();
            inboxStyle.AddLine("Cheeta: Bananas on sale");
            inboxStyle.AddLine("George: Curious about your blog post");
            inboxStyle.AddLine("Nikko: Need a ride to Evolve?");
            inboxStyle.SetSummaryText("+2 more");

            notyBuilder.SetStyle(inboxStyle);

            #endregion

            #region imageStyle

            var imageStyle = new Notification.BigPictureStyle();
            imageStyle.BigPicture(BitmapFactory.DecodeResource(Resources,Resource.Drawable.facebook));
            imageStyle.SetSummaryText("+2 more");
            //notyBuilder.SetStyle(imageStyle);
            

            #endregion

            var notification = notyBuilder.Build();
            var notyManager = GetSystemService(Context.NotificationService) as NotificationManager;
            notyManager.Notify(notyId, notification);

        }

        




        private void Btn_edit_Click(object sender, EventArgs e)
        {
            if (notyBuilder ==null)
            {
                Toast.MakeText(this,"هیچ نوتیفیکیشنی وجود ندارد",ToastLength.Short).Show();
            }
            else
            {

                notyBuilder.SetContentTitle("Updated Notification");
                notyBuilder.SetContentText("Changed to this message.");


                #region InboxStyle

                var inboxStyle = new Notification.InboxStyle();
                inboxStyle.AddLine("hamed: Bananas on sale");
                inboxStyle.AddLine("nili: Curious about your blog post");
                inboxStyle.AddLine("saeed: Need a ride to Evolve?");
                inboxStyle.SetSummaryText("+8 more");

                // Plug this style into the builder:
                notyBuilder.SetStyle(inboxStyle);

                #endregion
                var notification = notyBuilder.Build();
                var notyManager = GetSystemService(Context.NotificationService) as NotificationManager;
                notyManager.Notify(notyId, notification);
            }

        }



    }
}

