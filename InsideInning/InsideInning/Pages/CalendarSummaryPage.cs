using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class CalendarSummaryPage : Application
    {
        public CalendarSummaryPage()
        {
            var tabs = new TabbedPage { Title = "Calendar Summary" };
            tabs.Children.Add(new BalanceLeavePage { Title = "Leave", Icon = "icon.png" });
            tabs.Children.Add(new CalendarPage { Title = "Calendar", Icon = "icon.png" });
            tabs.Children.Add(new HolidayPage { Title = " Holiday", Icon = "icon.png" });

            MainPage = tabs;
        }
    }
}
