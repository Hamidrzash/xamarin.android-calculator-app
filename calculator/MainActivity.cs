using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Text.Method;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using System.Linq;
using Java.Lang;
using System.Threading.Tasks;

namespace calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        
        
        Stack<decimal> mylist = new Stack<decimal>();
        decimal old;
        string add;
        Stack<string> countamlgar = new Stack<string>();
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
        Button buttondelet;
        TextView textresult;
        TextView textrealresult;
        Button buttonzarb;
        Button buttonslash;
        Button buttontavan;
        Button buttondot;

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

            buttondelet = FindViewById<Button>(Resource.Id.buttondel);
            buttondelet.Click += buttondelclick;

            buttonzarb = FindViewById<Button>(Resource.Id.buttonzarb);
            buttonzarb.Click += buttonzarbclick;

            buttonslash = FindViewById<Button>(Resource.Id.buttontslash);
            buttonslash.Click += buttonslashclick;
            buttontavan = FindViewById<Button>(Resource.Id.buttontavan);
            buttontavan.Click += buttontavanclick;

            buttondot = FindViewById<Button>(Resource.Id.buttondot);
            buttondot.Click += buttonclick;
            


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public async void buttonclick(object sender, EventArgs eventArgs)
        {
            try
            {
               
                Button btn = (Button)sender;
                textresult.Text += btn.Text;
                var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                scrollview.PostDelayed(new Runnable(() =>
                {
                    scrollview.FullScroll(FocusSearchDirection.Right);
                }), 10L);
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }

        }
        public async void buttoncclick(object sender, EventArgs eventArgs)
        {

                textresult.TextChanged -= textchange;
                textresult.SetTextColor(Android.Graphics.Color.White);
                textrealresult.SetTextColor(Android.Graphics.Color.LightGray);
                mylist.Clear();
                add = "";
                old = 0;
                countamlgar.Clear();
                textresult.Text = "";
                textrealresult.Text = "";




        }
        public async void buttonplus(object sender, EventArgs eventArgs)
        {
            try {
                if (textresult.Text != "")
                {
                    textresult.TextChanged -= textchange;
                    if (textrealresult.Text == "")
                        old = decimal.Parse(textresult.Text);
                    else
                        old = decimal.Parse(textrealresult.Text);
                    mylist.Push(old);
                    textresult.Text += buttonpluss.Text;
                    countamlgar.Push(buttonpluss.Text);
                    fun = textresult.Text;
                    
                    textresult.TextChanged += textchange;
                    
                    //
                    var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                    scrollview.PostDelayed(new Runnable(() =>
                    {
                        scrollview.FullScroll(FocusSearchDirection.Right);
                    }), 10L);
                }
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);
                
                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }
        public async void textchange(object sender, EventArgs eventArgs)
        {
            try
            {
                
                    if (textresult.Text.Length < fun.Length)
                        fun.Remove(fun.Length - 1, 1);
                    else
                        add = (textresult.Text.Replace(fun, "", StringComparison.OrdinalIgnoreCase));
                    if (add == "")
                        add = "0";
                    if (fun[fun.Length - 1] == '+')
                        textrealresult.Text = (old + decimal.Parse(add)).ToString();
                    if (fun[fun.Length - 1] == '-')
                        textrealresult.Text = (old - decimal.Parse(add)).ToString();
                if (fun[fun.Length - 1] == '*')
                {
                    if (add == "0")
                        add = "1";
                    textrealresult.Text = (old * decimal.Parse(add)).ToString();
                }
                if (fun[fun.Length - 1] == '/')
                {
                    if (add == "0")
                        add = "1";
                    textrealresult.Text = (old / decimal.Parse(add)).ToString();
                }
                if (fun[fun.Length - 1] == '^')
                {
                    if (add == "0")
                        add = "1";
                    textrealresult.Text = (System.Math.Pow((double)old, double.Parse(add)).ToString());
                }
                    add = "";
                //}
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }


        }



        public async void buttonminesclick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text != "")
                {
                    textresult.TextChanged -= textchange;
                    if (textrealresult.Text == "")
                        old = decimal.Parse(textresult.Text);
                    else
                        old = decimal.Parse(textrealresult.Text);
                    mylist.Push(old);
                    textresult.Text += buttonmines.Text;
                    countamlgar.Push(buttonmines.Text);
                    fun = textresult.Text;
                    
                    textresult.TextChanged += textchange;

                    //
                    var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                    scrollview.PostDelayed(new Runnable(() =>
                    {
                        scrollview.FullScroll(FocusSearchDirection.Right);
                    }), 10L);
                }
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }

        public async void buttondelclick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text.Length == 0)
                {
                    
                    return;


                }
                if (textresult.Text.Length == 1)
                {
                    buttoncclick(null, null);
                    return;


                }
                
                if (textresult.Text[textresult.Text.Length - 2] == '+' || textresult.Text[textresult.Text.Length - 2] == '-' || textresult.Text[textresult.Text.Length - 2] == '*' || textresult.Text[textresult.Text.Length - 2] == '/' || textresult.Text[textresult.Text.Length - 2] == '^')
                {
                    
                    old = mylist.Peek();
                    

                }

                if (textresult.Text[textresult.Text.Length - 1] == '+' || textresult.Text[textresult.Text.Length - 1] == '-' || textresult.Text[textresult.Text.Length - 1] == '*' || textresult.Text[textresult.Text.Length - 1] == '/' || textresult.Text[textresult.Text.Length - 1] == '^')
                {
                    
                    if (textresult.Text.Remove(textresult.Text.Length - 1, 1).Contains('+') || textresult.Text.Remove(textresult.Text.Length - 1, 1).Contains('-') || textresult.Text.Remove(textresult.Text.Length - 1, 1).Contains('*') || textresult.Text.Remove(textresult.Text.Length - 1, 1).Contains('/') || textresult.Text.Remove(textresult.Text.Length - 1, 1).Contains('^'))
                    {
                        
                        mylist.Pop();
                        
                        old = mylist.Peek();
                        
                        



                        
                        fun = fun.Remove(fun.Length - 1, 1);
                        
                        countamlgar.Pop();
                            fun = fun.Remove(fun.LastIndexOf(countamlgar.Peek()), fun.Length - fun.LastIndexOf(countamlgar.Peek()));
                        
                        
                            
                        
                        if (textresult.Text[textresult.Text.Length - 1] == '+' || textresult.Text[textresult.Text.Length - 1] == '-' || textresult.Text[textresult.Text.Length - 1] == '*' || textresult.Text[textresult.Text.Length - 1] == '/' || textresult.Text[textresult.Text.Length - 1] == '^')

                            fun += countamlgar.Peek();
                        

                        }
                }
                textresult.Text = textresult.Text.Remove(textresult.Text.Length - 1, 1);
                
                
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }
        public async void buttonequal(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text != "")
                {

                    textresult.Text = textrealresult.Text;
                    old = 0;
                    add = "";

                    textrealresult.Text = "";
                }
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }

        }

        public async void buttonzarbclick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text != "")
                {
                    textresult.TextChanged -= textchange;
                    if (textrealresult.Text == "")
                        old = decimal.Parse(textresult.Text);
                    else
                        old = decimal.Parse(textrealresult.Text);
                    mylist.Push(old);
                    textresult.Text += buttonzarb.Text;
                    countamlgar.Push(buttonzarb.Text);
                    fun = textresult.Text;
                    
                    textresult.TextChanged += textchange;

                    //
                    var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                    scrollview.PostDelayed(new Runnable(() =>
                    {
                        scrollview.FullScroll(FocusSearchDirection.Right);
                    }), 10L);
                }
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }

        public async void buttonslashclick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text != "")
                {
                    textresult.TextChanged -= textchange;
                    if (textrealresult.Text == "")
                        old = decimal.Parse(textresult.Text);
                    else
                        old = decimal.Parse(textrealresult.Text);
                    mylist.Push(old);
                    textresult.Text += buttonslash.Text;
                    countamlgar.Push(buttonslash.Text);
                    fun = textresult.Text;
                    
                    textresult.TextChanged += textchange;

                    //
                    var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                    scrollview.PostDelayed(new Runnable(() =>
                    {
                        scrollview.FullScroll(FocusSearchDirection.Right);
                    }), 10L);
                }
                }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() => {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }
        public async void buttontavanclick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (textresult.Text != "")
                {
                    textresult.TextChanged -= textchange;
                    if (textrealresult.Text == "")
                        old = decimal.Parse(textresult.Text);
                    else
                        old = decimal.Parse(textrealresult.Text);
                    mylist.Push(old);
                    textresult.Text += "^";
                    countamlgar.Push("^");
                    fun = textresult.Text;
                    
                    textresult.TextChanged += textchange;

                    //
                    var scrollview = FindViewById<HorizontalScrollView>(Resource.Id.ScrollView);
                    scrollview.PostDelayed(new Runnable(() =>
                    {
                        scrollview.FullScroll(FocusSearchDirection.Right);
                    }), 10L);
                }
            }
            catch
            {
                textresult.SetTextColor(textrealresult.TextColors);
                textrealresult.SetTextColor(Android.Graphics.Color.White);

                textrealresult.Text = "Eror";
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });
                buttoncclick(null, null);
            }
        }

    }
}