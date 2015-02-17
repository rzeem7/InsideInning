using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class CalendarSummaryViewPage : Application
    {
        public CalendarSummaryViewPage()
        {
            var tabs = new TabbedPage { Title = "Calendar Summary" };
            tabs.Children.Add(new BalanceLeaveViewPage { Title = "Leave", Icon = "icon.png" });
            tabs.Children.Add(new CalendarViewPage { Title = "Calendar", Icon = "icon.png" });
            tabs.Children.Add(new HolidayViewPage { Title = " Holiday", Icon = "icon.png" });

            MainPage = tabs;
        }
    }
}
