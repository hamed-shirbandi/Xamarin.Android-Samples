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
using Android.Support.V7.Widget;
using Xamarin_RecycleView.Models;

namespace Xamarin_RecycleView.Adapters
{
    public class ContactAdapter : RecyclerView.Adapter
    {
        private RecyclerView _recyclerView;
        private List<Contact> _contacts;
        private Activity _activity;
        public ContactAdapter(Activity activity, RecyclerView recyclerView, List<Contact> contacts)
        {
            _activity = activity;
            _recyclerView = recyclerView;
            _contacts = contacts;
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Contact_Row, parent, false);
            itemView.Click += ItemView_Click;

            var delete_btn = itemView.FindViewById<Button>(Resource.Id.btn_delete);
            var contact_id = itemView.FindViewById<TextView>(Resource.Id.txt_id);

            delete_btn.Click += (s, e) =>
            {
                Toast.MakeText(_activity, contact_id.Text + " delete clicked", ToastLength.Short).Show();
            };

            return new ContactViewHolder(itemView);


        }




        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = _contacts[position];
            var holder = viewHolder as ContactViewHolder;
            holder.contact_name.Text = item.Name;
            holder.contact_numcer.Text = item.Number;
            holder.contact_id.Text = item.Id.ToString();

        }




        private void ItemView_Click(object sender, EventArgs e)
        {
            int position = _recyclerView.GetChildAdapterPosition((View)sender);
            var item = _contacts[position];
            Toast.MakeText(_activity, item.Name + " clicked", ToastLength.Short).Show();
        }



        public override int ItemCount => _contacts.Count;

    }
}