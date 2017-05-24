using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.Models;
using Newtonsoft.Json;

namespace Dialog_Fragment.Activities
{
    [Activity()]
    public class PanelActivity : Activity
    {
        User userInfo;


        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Panel);

            userInfo = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("userInfo"));
            var txt_name = FindViewById<TextView>(Resource.Id.txt_name);
            txt_name.Text = userInfo.DisplayName;


            var btn_main_page = FindViewById<Button>(Resource.Id.btn_main_page);
            btn_main_page.Click += Btn_main_page_Click;

            var btn_exit = FindViewById<Button>(Resource.Id.btn_exit);
            btn_exit.Click += Btn_exit_Click;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void OnBackPressed()
        {
            GoToMainPage();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Btn_main_page_Click(object sender, System.EventArgs e)
        {
            GoToMainPage();
        }



        /// <summary>
        /// 
        /// </summary>
        private void Btn_exit_Click(object sender, System.EventArgs e)
        {
            userInfo.IsLogin = false;
            GoToMainPage();
        }


        /// <summary>
        /// 
        /// </summary>
        private void GoToMainPage()
        {
            var intent = new Intent(this, typeof(MainActivity));

            intent.PutExtra("userInfo", JsonConvert.SerializeObject(userInfo));
            StartActivity(intent);

            OverridePendingTransition(Resource.Animation.slide_up, Resource.Animation.slide_down);


        }
    }
}