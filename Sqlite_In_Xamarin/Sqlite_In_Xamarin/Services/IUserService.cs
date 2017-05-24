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
using Sqlite_In_Xamarin.Domain;
using Sqlite_In_Xamarin.Services.Dto;

namespace Sqlite_In_Xamarin.Services
{
    public interface IUserService
    {
        void Create(UserInput input);
        void Update(UserInput input);
        UserInput Get(int id);
        void Delete(int id);
        void DeleteAll( );
        
        IList<string> Search(string term);

    }
}