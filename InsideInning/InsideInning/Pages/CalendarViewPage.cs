using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.iiCalendar;


namespace InsideInning.Pages
{
    public class CalendarViewPage : BaseViewPage
    {

        CalendarView _calendarView;
        StackLayout _stacker;

        public CalendarViewPage()
        {
            Title = "Calendar View";

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

  