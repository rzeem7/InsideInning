using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public enum MenuType
    {
        Dashboard,
        EmployeeAccount,
        Setting,
        Logout

    }
    
    public class HomeMenuItem : BaseModel
    {

        public HomeMenuItem()
        {
            MenuType = MenuType.Dashboard;
                
        }
        public MenuType MenuType { get; set; }
    }
}
  
 