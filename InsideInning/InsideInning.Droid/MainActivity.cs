using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

using ImageCircle.Forms.Plugin.Abstractions;

namespace InsideInning.Droid
{
    [Activity(Label = "InsideInning", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            
            SetPage(InsideInning.App.RootPage);
           // SetPage(App.GetMainPage());

        }
    }
}

