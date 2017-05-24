using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Xamarin_RecycleView.Adapters;
using Xamarin_RecycleView.Models;

namespace Xamarin_RecycleView
{
    [Activity(Label = "Xamarin_RecycleView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<Contact> contacts;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            contacts = new List<Contact> { new Contact {Name="hamed",Number="0918989998",Id=2 }, new Contact { Name = "saeed", Number = "09123232656", Id = 21 }, new Contact { Name = "koorosh", Number = "098686866", Id = 30}, new Contact { Name = "milad", Number = "09335656565", Id = 17 }, new Contact { Name = "kami", Number = "0938654545", Id = 18 }, new Contact { Name = "ali", Number = "03212254345", Id =65 }, new Contact { Name = "abas", Number = "98989898989", Id = 10 }, new Contact { Name = "messi", Number = "9565874654545", Id = 15 } };

            var recycler = FindViewById<RecyclerView>(Resource.Id.contacts_recyclerview);
            var layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            //var layoutManager = new GridLayoutManager(this,2);
            recycler.SetLayoutManager(layoutManager);
            var adapter = new ContactAdapter(this,recycler,contacts);
            recycler.SetAdapter(adapter);


        }


    }
}

