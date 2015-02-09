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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using InsideInning;
using InsideInning.Droid.Renderer;
[assembly: ExportRenderer(typeof(iiDatePicker), typeof(iiDatePickerRenderer))]
namespace InsideInning.Droid.Renderer
{
    public class iiDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                Control.SetBackgroundResource(Resource.Drawable.iiTextBox);
                if (e.NewElement.ClassId=="1")
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Birthday, 0, 0, 0);
                else
                    Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Joinning, 0, 0, 0);
            }
        }
    }
}