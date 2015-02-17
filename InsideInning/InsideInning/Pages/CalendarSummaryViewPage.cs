using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.iiCalendar;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
    public class CalendarSummaryViewPage : BaseViewPage
    {
        #region Private field declaration
        StackLayout layoutContent;
        private BalanceLeaveViewPage _balanceLeaveViewPage;
        private CalendarViewPage _calendarViewPage;
        private HolidayViewPage _holidayViewPage;
        ActivityIndicator indi = null;
        StackLayout parent = null;

        private TabView _tabView;
        #endregion        
        public CalendarSummaryViewPage()
        {
            BackgroundImage = "back";
            parent = BalanceLeaveLayout();
            Content = MainLayout();

        }

        #region MainLayout
        StackLayout MainLayout() //handling all view
        {
            var tabLayout = GenGrid();

            layoutContent = new StackLayout();//ContentLayout (); //Hold other content view
            layoutContent.Children.Clear();
            layoutContent.Children.Add(parent);

            var customLayout = new StackLayout
            {

                BackgroundColor =Xamarin.Forms.Color.Transparent,
                Children = {
					tabLayout, layoutContent
				}
            };
            return customLayout;
        }
        #endregion
        #region Custom Control for CalendarSummaryViewPage
        private Grid GenGrid()
        {
            var grid = new Grid()
            {
                BackgroundColor = Xamarin.Forms.Color.Silver,
                ColumnSpacing = 1,
                RowSpacing = 1,
                Padding = new Thickness(0, 0, 0, 3),

            };
            grid.Children.Add(CreateButtonFor("Balance ", "balance.png", "3"), 0, 0);
            grid.Children.Add(CreateButtonFor("Calendar", "Calendar.png", "4"), 1, 0);
            grid.Children.Add(CreateButtonFor("Holidays", "holiday.png", "5"), 2, 0);
            return grid;
        }
        public View CreateButtonFor(string propertyName, string imgSrc, string _id)
        {
            iiButton iiButton = new iiButton
            {
                Image = imgSrc,
                ClassId = _id,
                Text = propertyName,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Fill,
                TextColor = Color.White.ToFormsColor(),
                //BackgroundColor=Color.Blue.ToFormsColor(),
                HeightRequest = 50,
            };
            iiButton.Clicked += TabBtn_Clicked;

            return iiButton;
        }
        #endregion

        #region BalanceLeaveView
        StackLayout BalanceLeaveLayout()
        {
            BackgroundImage = "back";
            var BalanceLeaveTabView = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 0, 20, 10),
                //Spacing = 20,
                Children = 
                {
                  {(CreateListFor("Laeve Type"))},
                    GenCalGrid(),
                }
            };
            return BalanceLeaveTabView;
        }
        #endregion
        #region Custom Controls for balance leave page  
        private Grid GenCalGrid()
        {
            var grid = new Grid()
            {
                ColumnSpacing = 2,
                RowSpacing = 2,
            };

            grid.Children.Add(CreateLabelFor("Leave Type", LayoutOptions.Start, "2"), 0, 0);
            grid.Children.Add(CreateLabelFor("Total", Color.Purple, LayoutOptions.Start, "", true), 1, 0);
            grid.Children.Add(CreateLabelFor("Used", Color.Purple, LayoutOptions.Start, "", true), 2, 0);
            grid.Children.Add(CreateLabelFor("Pending", LayoutOptions.Start, "3"), 3, 0);

            grid.Children.Add(CreateLabelFor("Casual Leave", Color.Purple, LayoutOptions.Start, "", true), 0, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 1);

            grid.Children.Add(CreateLabelFor("Medical Leave", Color.Purple, LayoutOptions.Start, "", true), 0, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 2);

            grid.Children.Add(CreateLabelFor("Paid Leave", Color.Purple, LayoutOptions.Start, "", true), 0, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 3);

            return grid;
        }

        #region Custom Label
        public View CreateLabelFor(string propertyName, Color color, LayoutOptions layout, string id = "", bool isHeader = false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = isHeader ? Color.White.ToFormsColor() : Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 130,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor = color.ToFormsColor(),
            };
            return iiLabel;
        }
        public View CreateLabelFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 120,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            return iiLabel;
        }
        #endregion
        #region Custom ListView

        public static View CreateListFor(string propertyName)
        {

            var listView = new ListView();
            listView.VerticalOptions = LayoutOptions.Center;
            listView.ItemsSource = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            listView.ItemTapped += async (sender, e) =>
            {
                Console.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null;
            };
            var OuterLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(50, 0, 50, 0),
                Children =
                {
                    listView
                }
            };
            return OuterLayout;
        }

        #endregion
        #endregion

        #region HolidayView
        StackLayout HolidayViewLayout()
        {
            BackgroundImage = "back";
            var HolidayTabView = new StackLayout
            {
                Padding = new Thickness(40, 0, 40, 20),
                Spacing = 2,
                HorizontalOptions = LayoutOptions.Center,
                Children = 
                {
                   GenEventTablelGrid(),
                }
            };
            return HolidayTabView;
        }

        #endregion
        #region Custom Controls for Holiday page 
        public View CreateGridLabelFor(string propertyName, Color color, LayoutOptions layout, string id = "", bool isHeader = false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 35,
                WidthRequest = 140,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor = color.ToFormsColor(),
            };
            return iiLabel;
        }

        private Grid GenEventTablelGrid()
        {
            int i = 5;
            var grid = new Grid()
            {
                ColumnSpacing = 2,
                RowSpacing = 2,
            };
            grid.Children.Add(CreateGridLabelFor("Event ", Color.Purple, LayoutOptions.Start, "", true), 0, 0);
            grid.Children.Add(CreateGridLabelFor("Details ", Color.Purple, LayoutOptions.Start, "", true), 1, 0);
            for (int j = 1; j <= i; j++)
            {
                grid.Children.Add(CreateGridLabelFor("Event {0}" + j, Color.Pink, LayoutOptions.Start, "", true), 0, j);
                grid.Children.Add(CreateGridLabelFor("Detail{0}" + j, Color.Pink, LayoutOptions.Start, "", true), 1, j);
            }
            return grid;
        }
        #endregion

        #region CalendarView
        StackLayout CalendarViewLayout()
        {
            CalendarView _calendarView;
            StackLayout _stacker;
            //Title = "Calendar View";
            _stacker = new StackLayout();
            // Content = _stacker;
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
            return _stacker;
        }
        #endregion

        #region TabButton_Click
        void TabBtn_Clicked(object sender, EventArgs e)
        {
            string id = ((iiButton)sender).ClassId;
            switch (id)
            {
                case "3":
                    try
                    {
                        _tabView = TabView.Balance;
                        layoutContent.Children.Clear();
                        parent = BalanceLeaveLayout();
                        layoutContent.Children.Clear();
                        layoutContent.Children.Add(parent);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
                case "4":
                    try
                    {
                        _tabView = TabView.Calendar;
                        layoutContent.Children.Clear();
                        parent = CalendarViewLayout();
                        layoutContent.Children.Clear();
                        layoutContent.Children.Add(parent);

                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    break;
                case "5":
                    try
                    {
                         _tabView = TabView.Holidays;
                        layoutContent.Children.Clear();
                        parent = HolidayViewLayout();
                        layoutContent.Children.Clear();
                        layoutContent.Children.Add(parent);

                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
