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
                BackgroundColor = Helper.Color.Pink.ToFormsColor(),
                BarTextColor = Helper.Color.White.ToFormsColor(),
                BarBackgroundColor= Helper.Color.iiGreen.ToFormsColor()
            };
            Detail = homeNav;
            pages.Add(MenuType.Dashboard, homeNav);
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
            private MenuType menuType = MenuType.Dashboard;

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

            private EmployeeAccount EmployeeAccount;
            private DashboardView DashBoard;
            private Login Setting;
            private Login Logout;
            public HomeMasterPage(HomeViewModel viewModel)
            {

                this.Icon = "slideout.png";
                Title = "test";
                var layout = new StackLayout { Spacing = 0 };

                var listView = new ListView(); // Listview created for menu items
                var cell = new DataTemplate(typeof(ListImageCell));
                cell.SetBinding(TextCell.TextProperty, HomeViewModel.TitlePropertyName);

                listView.ItemTemplate = cell;

                listView.ItemsSource = viewModel.MenuItems;
                listView.BackgroundColor= Xamarin.Forms.Color.Gray;
                if (DashBoard == null)   //Making First view page selection
                    DashBoard = new DashboardView();
                PageSelection = DashBoard;

                listView.ItemSelected += (sender, args) =>
                {
                    
                    var menuItem = listView.SelectedItem as HomeMenuItem;
                    menuType = menuItem.MenuType;
                    switch (menuItem.MenuType)
                    {
                        case MenuType.Dashboard:
                            if (DashBoard == null)
                                DashBoard = new DashboardView();

                            PageSelection = DashBoard;
                            break;
                        case MenuType.EmployeeAccount:
                            if (EmployeeAccount == null)
                                EmployeeAccount = new EmployeeAccount();
                            PageSelection = EmployeeAccount;
                            break;

                        case MenuType.Setting:
                            if (Setting == null)
                                Setting = new Login();

                            PageSelection = Setting;
                            break;

                        case MenuType.Logout:
                            if (Logout == null)
                                Logout = new Login();

                            PageSelection = Logout;
                            break;
                    }
                };
                layout.Children.Add(listView);
                Content = layout;
            }
        }
    }
}
