using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Helper
{
    public class iiControls
    {
        public static View CreateEntryFor(string propertyName, Color color, bool IsPassword = false)
        {
            Entry iiEditTextBox = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = color.ToFormsColor(),
                IsPassword = IsPassword,
                Placeholder = propertyName
            };
            iiEditTextBox.SetBinding(Entry.TextProperty, propertyName);
            return iiEditTextBox;
        }

    }
}
