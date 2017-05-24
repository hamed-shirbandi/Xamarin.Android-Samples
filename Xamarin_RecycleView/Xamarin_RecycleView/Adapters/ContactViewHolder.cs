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

namespace Xamarin_RecycleView.Adapters
{
   public class ContactViewHolder :RecyclerView.ViewHolder
    {
       public TextView contact_name;
       public TextView contact_numcer;
       public TextView contact_id;
        public ContactViewHolder(View itemView):base(itemView)
        {
            contact_name = itemView.FindViewById<TextView>(Resource.Id.txt_name);
            contact_numcer = itemView.FindViewById<TextView>(Resource.Id.txt_number);
            contact_id = itemView.FindViewById<TextView>(Resource.Id.txt_id);

        }



     
    }
}