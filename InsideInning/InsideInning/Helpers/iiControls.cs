using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Helper
{
    public class iiControls
    {
        public static View CreateEntryFor(string propertyName, Color color, string id="", bool IsPassword = false)
        {
            iiTextBox iiEditTextBox = new iiTextBox
            {
               // HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = color.ToFormsColor(),
                IsPassword = IsPassword,
                Placeholder = propertyName,
                BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,
                TranslationY = 2,     

            };
            if (id == "1")
                iiEditTextBox.HorizontalOptions = LayoutOptions.EndAndExpand;
            else if(id == "2")
                iiEditTextBox.HorizontalOptions = LayoutOptions.StartAndExpand;

            iiEditTextBox.HorizontalOptions = LayoutOptions.FillAndExpand;
            iiEditTextBox.SetBinding(iiTextBox.TextProperty, propertyName);
            return iiEditTextBox;
        }

    }
}
