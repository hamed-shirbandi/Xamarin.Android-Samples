using Android.App;
using Android.Widget;
using Android.OS;
using Dialog_Fragment.Fragments;
using Core.Models;
using Android.Content;
using Newtonsoft.Json;
using System;

namespace Dialog_Fragment.Activities
{
    [Activity(MainLauncher = true)]
    public class MainActivity : Activity
    {
        User userInfo;
        Button btn_show_signup_dialog;
        Button btn_show_login_dialog;


        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            CheckIfComeFromPanel();

            HandleViewElements();

        }





        /// <summary>
        /// 
        /// </summary>
        public override void OnBackPressed()
        {
            var alert = new AlertDialog.Builder(this);
            alert.SetTitle("خروج از برنامه");
            alert.SetMessage("آیا میخواهید از برنامه خارج شوید؟");
            alert.SetPositiveButton("بله", (s, e) =>
             {
                 FinishAffinity();
             });

            alert.SetNegativeButton("خیر", (s, e) =>
            {

            });

            var dialog = alert.Create();
            dialog.Show();
        }




        /// <summary>
        /// 
        /// </summary>
        private void HandleViewElements()
        {
            btn_show_login_dialog = FindViewById<Button>(Resource.Id.btn_show_login_dialog);
            btn_show_signup_dialog = FindViewById<Button>(Resource.Id.btn_show_signup_dialog);
            btn_show_signup_dialog.Click += Btn_show_signup_dialog_Click;
            btn_show_login_dialog.Click += Btn_show_login_dialog_Click;
        }




        /// <summary>
        /// 
        /// </summary>
        private void CheckIfComeFromPanel()
        {
            var userExtraInfo = Intent.GetStringExtra("userInfo") ?? "";
            if (userExtraInfo != "")
            {
                userInfo = JsonConvert.DeserializeObject<User>(userExtraInfo);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        private void Btn_show_signup_dialog_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transation = FragmentManager.BeginTransaction();
            SignUpDialog dialog = new SignUpDialog();
            dialog.OnSignUpComplete += Dialog_OnSignUpComplete;
            dialog.Show(transation, "SignUpDialog");
        }






        /// <summary>
        /// 
        /// </summary>
        private void Dialog_OnSignUpComplete(object sender, User e)
        {
            userInfo = e;
        }



        /// <summary>
        /// 
        /// </summary>
        private void Btn_show_login_dialog_Click(object sender, System.EventArgs e)
        {


            if (userInfo == null)
            {
                userInfo = new User();
            }

            if (userInfo.IsLogin)
            {
                GoToPanel(userInfo);
            }
            else
            {
                FragmentTransaction transation = FragmentManager.BeginTransaction();
                //FragmentManager.PopBackStack("LoginDialog", PopBackStackFlags.Inclusive);
                LoginDialog dialog = new LoginDialog(userInfo);
                dialog.OnLoginComplete += Dialog_OnLoginComplete;
                dialog.Show(transation, "LoginDialog");
            }


        }


        /// <summary>
        /// 
        /// </summary>
        private void Dialog_OnLoginComplete(object sender, User e)
        {

            if (e.Email == userInfo.Email && e.Pass == userInfo.Pass)
            {
                GoToPanel(e);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        private void GoToPanel(User user)
        {
            var intent = new Intent(this, typeof(PanelActivity));
            intent.PutExtra("userInfo", JsonConvert.SerializeObject(user));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_up, Resource.Animation.slide_down);

        }
    }
}

