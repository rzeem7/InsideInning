using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class NotificationPageCell : ContentPage
    {
        public NotificationPageCell()
        {
            var listView = new ListView();
            listView.ItemsSource = new[] { "1", "2", "3","4"};
            listView.ItemTapped += async (sender ,e)=>
                {
                    await DisplayAlert("Tapped",e.Item +"row was tapped", "OK");
                    Debug.WriteLine("Tapped: " + e.Item);
                    ((ListView)sender).SelectedItem = null; 
                };
            
            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
    }
}
