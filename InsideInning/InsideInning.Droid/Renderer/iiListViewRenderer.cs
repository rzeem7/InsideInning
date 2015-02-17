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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using InsideInning.Droid.Renderer;
using InsideInning;

[assembly: ExportRenderer(typeof(iiListView), typeof(iiListViewRenderer))]

namespace InsideInning.Droid.Renderer
{
    class iiListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            Control.SetBackgroundResource(Resource.Drawable.back);
        }
    }
}