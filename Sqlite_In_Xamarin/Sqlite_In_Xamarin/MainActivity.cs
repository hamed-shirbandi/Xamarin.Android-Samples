using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Sqlite_In_Xamarin.Context;
using Sqlite_In_Xamarin.Services;
using System.Linq;
using Sqlite_In_Xamarin.Services.Dto;
using System.Collections.Generic;

namespace Sqlite_In_Xamarin
{
    [Activity(Label = "Sqlite_In_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private IUserService userService;
        private ListView userListView;
        private Button btn_add;
        private Button btn_clear_all;
        private EditText txt_name;
        private ArrayAdapter<string> adapter;
        private IList<string>  usersList;

        public MainActivity()
        {
            userService = new UserService();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            CreateDatabase();

            btn_add = FindViewById<Button>(Resource.Id.btn_add);
            btn_add.Click += Btn_add_Click;

            btn_clear_all = FindViewById<Button>(Resource.Id.btn_clear_all);
            btn_clear_all.Click += Btn_clear_all_Click;
            userListView = FindViewById<ListView>(Resource.Id.user_list_view);
            userListView.ItemClick += UserListView_ItemClick;


            ShowUSersListInListView();


        }

        private void Btn_clear_all_Click(object sender, EventArgs e)
        {
            userService.DeleteAll();
            ShowUSersListInListView();
        }



        /// <summary>
        /// 
        /// </summary>
        private void ShowUSersListInListView()
        {
            usersList = userService.Search(term: "");

             adapter= new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, usersList);
            userListView.Adapter = adapter;
        }




        /// <summary>
        /// 
        /// </summary>
        private void Btn_add_Click(object sender, EventArgs e)
        {
            var txt_name= FindViewById<EditText>(Resource.Id.txt_name);
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                txt_name.Error = "please insert user name";
            }
            else
            {
                var user = new UserInput
                {
                    Name = txt_name.Text
                };
                userService.Create(user);
                ShowUSersListInListView();
            }



        }



        /// <summary>
        /// 
        /// </summary>
        private void UserListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this,e.Position+" clicked",ToastLength.Short).Show();
        }




        /// <summary>
        /// 
        /// </summary>
        private void CreateDatabase()
        {
            var con = new MainContext();
            con.CreateDatabase();
            con.Seed();
        }
    }
}

