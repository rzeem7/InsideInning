using InsideInning.Helper;
using InsideInning.Models;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class HomeView : MasterDetailPage
    {
            private HomeViewModel ViewModel
            {
                get { return BindingContext as HomeViewModel; } //Type cast BindingContex as HomeViewModel to access binded properties
            }

        private Dictionary<MenuType, NavigationPage> pages;
        HomeMasterPage _master;

        public HomeView()
        {
            pages = new Dictionary<MenuType, NavigationPage>();
            BindingContext = new HomeViewModel();
            Master = _master = new HomeMasterPage(ViewModel);

            var homeNav = new NavigationPage(_master.PageSelection)
            {
                BackgroundColor = Helper.Color.Green.ToFormsColor(),
                BarTextColor = Helper.Color.LightGray.ToFormsColor()
            };
            Detail = homeNav;
            pages.Add(MenuType.EmployeeDetails, homeNav);
            _master.PageSelectionChanged = async (menuType) =>
            {

                if (Detail != null && Device.OS == TargetPlatform.WinPhone)
                {
                    await Detail.Navigation.PopToRootAsync();
                }

                NavigationPage newPage;
                if (pages.ContainsKey(menuType))
                {
                    newPage = pages[menuType];
                }
                else
                {
                    newPage = new NavigationPage(_master.PageSelection)
                    {
                        BarBackgroundColor = Helper.Color.iiPurple.ToFormsColor(),
                        BarTextColor = Xamarin.Forms.Color.White
                    };
                    pages.Add(menuType, newPage);
                }
                Detail = newPage;
                Detail.Title = _master.PageSelection.Title;
                IsPresented = false;
            };
            this.Icon = "slideout.png";

        }
        public class HomeMasterPage : BaseView
        {
            public Action<MenuType> PageSelectionChanged;
            private Page _pageSelection;
            private MenuType menuType = MenuType.EmployeeDetails;

            public Page PageSelection
            {
                get { return _pageSelection; }
                set
                {
                    _pageSelection = value;
                    if (PageSelectionChanged != null)
                        PageSelectionChanged(menuType);
                }
            }

            private EmployeeDetailsPage EmployeeDetails;
            private LeaveDetails LeaveDetails;
            private LeaveRequest LeaveRequest;
            public HomeMasterPage(HomeViewModel viewModel)
            {
                this.Icon = "slideout.png";
                Title = "test";
                var layout = new StackLayout { Spacing = 0 };
                //var label = new ContentView
                //{
                //    Padding = new Thickness(10, 36, 0, 5),
                //    BackgroundColor = Xamarin.Forms.Color.Transparent,
                //    Content = new Label
                //    {
                //        Text = "MENU",
                //        Font = Font.SystemFontOfSize(NamedSize.Medium)
                //    }
                //};
                //layout.Children.Add(label);

                var listView = new ListView(); // Listview created for menu items
                var cell = new DataTemplate(typeof(ListImageCell));
                cell.SetBinding(TextCell.TextProperty, HomeViewModel.TitlePropertyName);

                listView.ItemTemplate = cell;

                listView.ItemsSource = viewModel.MenuItems;

                if (EmployeeDetails == null)   //Making First view page selection
                    EmployeeDetails = new EmployeeDetailsPage();
                PageSelection = EmployeeDetails;

                listView.ItemSelected += (sender, args) =>
                {
                    var menuItem = listView.SelectedItem as HomeMenuItem;
                    menuType = menuItem.MenuType;
                    switch (menuItem.MenuType)
                    {
                        case MenuType.EmployeeDetails:
                            if (EmployeeDetails == null)
                                EmployeeDetails = new EmployeeDetailsPage();
                            PageSelection = EmployeeDetails;
                            break;

                        case MenuType.LeaveDetails:
                            if (LeaveDetails == null)
                                LeaveDetails = new LeaveDetails();

                            PageSelection = LeaveDetails;
                            break;

                        case MenuType.LeaveRequest:
                            if (LeaveRequest == null)
                                LeaveRequest = new LeaveRequest();

                            PageSelection = LeaveRequest;
                            break;
                    }
                };
                layout.Children.Add(listView);
                Content = layout;
            }
        }
    }
}
