using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InsideInning.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public HomeViewModel()
        {
            Title = "Hello";
            MenuItems = new ObservableCollection<HomeMenuItem>();
            MenuItems.Add(new HomeMenuItem
            {
                ID = 0,
                Title = "Create an Account",
                MenuType = MenuType.EmployeeDetails
            });
            MenuItems.Add(new HomeMenuItem
            {
                ID = 1,
                Title = "Leave Summary",
                MenuType = MenuType.LeaveDetails
            });
            MenuItems.Add(new HomeMenuItem
            {
                ID = 2,
                Title = "Setting",
                MenuType = MenuType.LeaveRequest
            });
            MenuItems.Add(new HomeMenuItem
            {
                ID = 3,
                Title = "LogOut",
                MenuType = MenuType.LeaveRequest
            });
        }
    }
}
