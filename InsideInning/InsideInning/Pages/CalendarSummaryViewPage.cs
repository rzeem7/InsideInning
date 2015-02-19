using ImageCircle.Forms.Plugin.Abstractions;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ListView listView = null;

        private TabView _tabView;

        #endregion
        private EmployeeViewModel ViewModel
        {
            get { return BindingContext as EmployeeViewModel; }
        }
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

                BackgroundColor = Xamarin.Forms.Color.Transparent,
                Children =
				{
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
                BackgroundColor = Xamarin.Forms.Color.Transparent,
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
					{ (CreateListFor("Laeve Type")) },
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
            //iiLabel.SetBinding(iiLabel.TextProperty,)
            return iiLabel;
        }

        #endregion

        #region Custom ListView

        public static View CreateListFor(string propertyName)
        {

            var listView = new ListView();
            listView.VerticalOptions = LayoutOptions.Center;
            //listView.ItemsSource = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //listView.ItemTapped += async (sender, e) =>
            //{
            //    Console.WriteLine("Tapped: " + e.Item);
            //    ((ListView)sender).SelectedItem = null;
            //};
            listView.ItemTemplate = new DataTemplate(typeof(EmployeeViewCell));

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

                if (_stacker.Children.Count > 1)
                    _stacker.Children.RemoveAt(1);
                _stacker.Children.Add(GenTabGrid());
            };
            return _stacker;
        }

        #endregion

        #region Custom Controls for CalendarView

        private Grid GenTabGrid()
        {
            int i = 0;
            var grid = new Grid()
            {
                ColumnSpacing = 2,
                RowSpacing = 2,
                Padding = new Thickness(10, 0, 10, 0),

            };

            grid.Children.Add(CreateLabelFor("Name", LayoutOptions.Start, "2"), 0, 0);
            grid.Children.Add(CreateLabelFor("From", Color.Purple, LayoutOptions.Start, "", true), 1, 0);
            grid.Children.Add(CreateLabelFor("To", Color.Purple, LayoutOptions.Start, "", true), 2, 0);
            grid.Children.Add(CreateLabelFor("Total Days", LayoutOptions.Start, "3"), 3, 0);
            for (int j = 1; j <= TempData.GetData().Count ; j++)
            {
                grid.BindingContext = TempData.GetData()[i];
                grid.Children.Add(CreateBindLabelFor("FirstName", Color.Purple, LayoutOptions.Start, "", true), 0, j);
                grid.Children.Add(CreateBindLabelFor("FromDate", Color.White, LayoutOptions.Start), 1, j);
                grid.Children.Add(CreateBindLabelFor("ToDate", Color.White, LayoutOptions.Start), 2, j);
                grid.Children.Add(CreateBindLabelFor("NoOfDays", Color.White, LayoutOptions.Start), 3, j);
                i++;
            }
            return grid;
        }
        public View CreateBindLabelFor(string propertyName, Color color, LayoutOptions layout, string id = "", bool isHeader = false)
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
            iiLabel.SetBinding(Label.TextProperty, propertyName);
            return iiLabel;
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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : {0}", ex.InnerException);
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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : {0}", ex.InnerException);
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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : {0}", ex.InnerException);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion 
    }
    #region Custom View cell
    /// <summary>
    /// This class is a ViewCell that will be displayed for each Employee Cell.
    /// </summary>
    class EmployeeViewCell : ViewCell
    {
        public EmployeeViewCell()
        {
            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            nameLabel.FontSize = 15;
            nameLabel.SetBinding(Label.TextProperty, "FirstName");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 1.5, 0, 1.5),
                HeightRequest = 10,
                Spacing = 0,
                Children = {
					new StackLayout {
                        Spacing=0,
						Orientation = StackOrientation.Vertical,
                        VerticalOptions=LayoutOptions.Start,
                        Padding=0,
						Children = { nameLabel }
					},
					
				}
            };

        }
    }
    #endregion
    public class TempData
    {
        public string FirstName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string NoOfDays
        {
            get
            {
                var days = (Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate)).TotalDays;
                return string.Format("{0} day{1}", days, days == 1 ? string.Empty : "s");
            }
        }

        public static ObservableCollection<TempData> GetData()
        {
            return new ObservableCollection<TempData>() { new TempData { FirstName = "Naina", FromDate = DateTime.Now.AddDays(1).ToShortDateString(),
                ToDate = DateTime.Now.AddDays(2).ToShortDateString() },
             new TempData { FirstName = "Neha", FromDate = DateTime.Now.AddDays(1).ToShortDateString(),
                 ToDate = DateTime.Now.AddDays(5).ToShortDateString() }
            };
        }
    }
}
