using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using eslansa.Adapters;
using eslansa.Models;

namespace eslansa.Fragments
{
    public class fragmentDetailProducts : Fragment
    {
        Products productObj = new Products();
        MainActivity parent = null;
        Button btnText = null;

        public fragmentDetailProducts(MainActivity _parent) : base()
        {
            parent = _parent;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View v = inflater.Inflate(Resource.Layout.fragment_detail_products, container, false);
            btnText = v.FindViewById<Button>(Resource.Id.button1);
            String _id = Arguments.GetString("id");
            int id = 0;
            if (_id == null)
            {
                id = 1;
            }
            else {
                int.TryParse(_id, out id);
            }
            Products.get(id, render);
            return v;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public int render(Products o)
        {
            btnText.Text = o.nombreProducto;
            return 0;
        }
    }
}