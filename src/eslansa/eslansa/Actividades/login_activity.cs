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

namespace eslansa.Actividades
{
    [Activity(Label = "login_activity")]
    public class login_activity : Activity
    {
        Button btnIngresa;
        Button btnRegistrate;
        EditText txtUsuario;
        EditText txtContraseña;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login_activity);
            btnIngresa = FindViewById<Button>(Resource.Id.btnIngresa);
            btnRegistrate = FindViewById<Button>(Resource.Id.btnRegistrate);
            txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            txtContraseña = FindViewById<EditText>(Resource.Id.txtContraseña);
        }

        private void ingresar(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                Toast.MakeText(this, "Debe ingresar un usuario", ToastLength.Long).Show();
                return;
            }
            if (txtContraseña.Text == string.Empty)
            {
                Toast.MakeText(this, "Debe ingresar una contraseña", ToastLength.Long).Show();
                return;
            }

        }
    }
}