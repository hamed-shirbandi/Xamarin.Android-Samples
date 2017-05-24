using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using Sqlite_In_Xamarin.Domain;

namespace Sqlite_In_Xamarin.Context
{
    public class MainContext : SQLiteConnection
    {
        //https://github.com/praeclarum/sqlite-net  
        //https://github.com/oysteinkrog/SQLite.Net-PCL
        //http://valokafor.com/sqlite-database-in-xamarin-android/
        private SQLiteConnection con;
        private static string dbFullPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user2.db3");

        public MainContext() : base(dbFullPath)
        {
            con = new SQLiteConnection(dbFullPath);
        }



        public void CreateDatabase()
        {
            con.CreateTable<User>();
        }



        public void Seed()
        {
            if (!con.Table<User>().Any())
            {

                var user = new User
                {
                    Name = "hamed"
                };
                con.Insert(user);



                con.Insert(new User
                {
                    Name = "saeed"
                });
            }
        }

    }
}