using InsideInning.Calendar;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace InsideInning.Pages
{
    public class CalendarPage : ContentPage 
    {
        
        CalendarView _calendarView;
        StackLayout _stacker;

        public CalendarPage()
            {
                Title = "Calendar Sample";

                _stacker = new StackLayout();
                Content = _stacker;

                _calendarView = new CalendarView()
                {
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                _stacker.Children.Add(_calendarView);
                _calendarView.DateSelected += (object sender, DateTime e) =>
                {
                    _stacker.Children.Add(new Label()
                    {
                        Text = "Date Was Selected" + e.ToString("d"),
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    });
                };
            }
    }
}

  