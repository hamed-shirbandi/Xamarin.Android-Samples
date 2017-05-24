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
using Sqlite_In_Xamarin.Services.Dto;
using Sqlite_In_Xamarin.Domain;
using SQLite;
using Sqlite_In_Xamarin.Context;

namespace Sqlite_In_Xamarin.Services
{
    public class UserService : IUserService
    {

        private MainContext con;
        private TableQuery<User> users;



        public UserService()
        {
            con = new MainContext();
            users = con.Table<User>();
        }





        /// <summary>
        /// 
        /// </summary>
        public void Create(UserInput input)
        {
            var user = new User
            {
                Name=input.Name
            };

            con.Insert(user);
        }




        /// <summary>
        /// 
        /// </summary>
        public void Delete(int id)
        {
            var user = users.FirstOrDefault(u=>u.Id==id);
            if (user!=null)
            {
                con.Delete(user);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteAll( )
        {
            con.DeleteAll<User>();
        }




        /// <summary>
        /// 
        /// </summary>
        public UserInput Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);


            if (user == null)
            {
                throw new Exception("user not found");
            }

            return new UserInput
            {
                Id=user.Id,
                Name=user.Name
            };
        }




        /// <summary>
        /// 
        /// </summary>
        public IList<string> Search(string term)
        {
            var uss = users.Where(u => u.Name.Contains(term)).ToList();
            return uss.Where(u=>u.Name.Contains(term)).Select(u => u.Name).ToList();
        }




        /// <summary>
        /// 
        /// </summary>
        public void Update(UserInput input)
        {
            var user = users.FirstOrDefault(u => u.Id == input.Id);


            if (user == null)
            {
                throw new Exception("user not found");
            }

            user.Name = input.Name;

            con.Update(user);
        }
    }
}