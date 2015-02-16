using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using InsideInning;
using InsideInning.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(iiDatePicker), typeof(iiDatePickerRenderer))]

namespace InsideInning.iOS.Renderer
{
    public class iiDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.BorderColor = UIColor.White.CGColor;
                Control.Layer.BorderWidth = 1f;
                Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.CornerRadius = 0;
                Control.ClipsToBounds = true;
                switch (e.NewElement.ClassId)//Set icon on datepicker through Id
                {
                    case "1":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Birthday, 0, 0, 0);
                        break;
                    case "2":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Joinning, 0, 0, 0);
                        break;
                    case "3":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.ToDate, 0, 0, 0);
                        break;
                    case "4":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.FromDate, 0, 0, 0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}