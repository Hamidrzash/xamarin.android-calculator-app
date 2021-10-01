﻿using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Widget.Inline;
using System;

namespace calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int old;
        string add;
        string fun;
        Button buttonmines;
        Button buttonzero;
        Button buttonone;
        Button buttontwo;
        Button buttonthree;
        Button buttonfour;
        Button buttonfive;
        Button buttonsix;
        Button buttonseven;
        Button buttoneight;
        Button buttonnine;
        Button buttonc;
        Button buttonpluss;
        Button buttonequall;
        TextView textresult;
        TextView textrealresult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            textresult = FindViewById<TextView>(Resource.Id.textView1);
            
            textrealresult = FindViewById<TextView>(Resource.Id.textrealresult);
            buttonzero = FindViewById<Button>(Resource.Id.buttonzero);
            buttonzero.Click += buttonclick;

            buttonone = FindViewById<Button>(Resource.Id.buttonone);
            buttonone.Click += buttonclick;

            buttontwo = FindViewById<Button>(Resource.Id.buttontwo);
            buttontwo.Click += buttonclick;

            buttonthree = FindViewById<Button>(Resource.Id.buttonthree);
            buttonthree.Click += buttonclick;

            buttonfour = FindViewById<Button>(Resource.Id.buttonfour);
            buttonfour.Click += buttonclick;

            buttonfive = FindViewById<Button>(Resource.Id.buttonfive);
            buttonfive.Click += buttonclick;

            buttonsix = FindViewById<Button>(Resource.Id.buttonsix);
            buttonsix.Click += buttonclick;

            buttonseven = FindViewById<Button>(Resource.Id.buttonseven);
            buttonseven.Click += buttonclick;

            buttoneight = FindViewById<Button>(Resource.Id.buttoneight);
            buttoneight.Click += buttonclick;

            buttonnine = FindViewById<Button>(Resource.Id.buttonnine);
            buttonnine.Click += buttonclick;

            buttonc = FindViewById<Button>(Resource.Id.buttonc);
            buttonc.Click += buttoncclick;

            buttonpluss = FindViewById<Button>(Resource.Id.buttonplus);
            buttonpluss.Click += buttonplus;

            buttonequall = FindViewById<Button>(Resource.Id.buttonequal);
            buttonequall.Click += buttonequal;

            buttonmines = FindViewById<Button>(Resource.Id.buttonmines);
            buttonmines.Click += buttonminesclick;


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void buttonclick(object sender,EventArgs eventArgs)
        {
            Button btn = (Button)sender;
            textresult.Text += btn.Text;
        }
        public void buttoncclick(object sender, EventArgs eventArgs)
        {
            add = "";
            old = 0;
            textresult.Text = "";
            textrealresult.Text = "";
            
        }
        public void buttonplus(object sender, EventArgs eventArgs) {

            textresult.TextChanged -= textchange;
            if (textrealresult.Text == "")
                old += int.Parse(textresult.Text);
            else
                old = int.Parse(textrealresult.Text);
            
            textresult.Text += buttonpluss.Text;
            fun = textresult.Text;
            //textresult.Text = "";
            textresult.TextChanged += textchange;
        }
        public void textchange(object sender, EventArgs eventArgs)
        {
            //if (old != 0)
            //{
                
                add = (textresult.Text.Replace(fun,"",StringComparison.OrdinalIgnoreCase));
                if (fun[fun.Length - 1] == '+')
                    textrealresult.Text = (old + int.Parse(add)).ToString();
                if (fun[fun.Length - 1] == '-')
                    textrealresult.Text = (old - int.Parse(add)).ToString();
                add = "";
            //}
        }



        public void buttonminesclick(object sender, EventArgs eventArgs)
        {

            textresult.TextChanged -= textchange;
            if (textrealresult.Text == "")
                old += int.Parse(textresult.Text);
            else
                old = int.Parse(textrealresult.Text);

            textresult.Text += buttonmines.Text;
            fun = textresult.Text;
            //textresult.Text = "";
            textresult.TextChanged += textchange;
        }


        public void buttonequal(object sender, EventArgs eventArgs)
        {
            if (textresult.Text != "")
            {
                
                textresult.Text = textrealresult.Text;
                old = 0;
                add = "";
                old = 0;
                textrealresult.Text = "";
            }


        }
    }
}