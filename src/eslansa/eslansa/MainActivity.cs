﻿using System;
using Android;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Android.Widget;
using eslansa.Actividades;
using eslansa.Fragments;
using System.Collections.Generic;

namespace eslansa
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);


            

        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                Intent newActivity = new Android.Content.Intent(this, typeof(login_activity));
                this.StartActivity(newActivity);
            }
            else if (id == Resource.Id.nav_gallery)
            {
                Intent newActivity = new Android.Content.Intent(this, typeof(registrate_activity));
                this.StartActivity(newActivity);
            }
            else if (id == Resource.Id.nav_slideshow)
            {
                Intent newActivity = new Android.Content.Intent(this, typeof(detalleproducto_activity));
                this.StartActivity(newActivity);
            }
            else if (id == Resource.Id.nav_manage)
            {
                Intent newActivity = new Android.Content.Intent(this, typeof(carrito_activity));
                this.StartActivity(newActivity);
                
            }
            else if (id == Resource.Id.nav_share)
            {
                changeFrame("aboutus");
                
            }
            else if (id == Resource.Id.nav_send)
            {
                changeFrame("products");
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }


        private void login(object sender, EventArgs e)
        {

        }
        public void changeFrame(string _type)
        {
            this.changeFrame(_type, null);
        }

        private void changeFrame(string _type, Dictionary<string, string> _params)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Bundle bundleParams = new Bundle();
            Fragment fragment = null;
            if (_type.Equals("aboutus"))
            {
                fragment = new FragmentAboutUs();
            }
            else if (_type.Equals("products"))
            {
                fragment = new FragmentProductos();
            }
            else if (_type.Equals("detail_products"))
            {
                foreach (string o in _params.Keys)
                {
                    bundleParams.PutString(o, _params[o]);
                }
                fragment = new fragmentDetailProducts(this);
            }
            else
            {

            }
            if (fragment != null)
            {
                fragment.Arguments = bundleParams;
                ft.Replace(Resource.Id.fragmentManyo, fragment);
                //ft.AddToBackStack(null);
                ft.SetTransition(FragmentTransit.FragmentFade);
                ft.Commit();
            }

        }
    }
}

