using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public enum MenuType
    {
        EmployeeDetails,
        LeaveDetails,
        LeaveRequest

    }
    
    public class HomeMenuItem : BaseModel
    {

        public HomeMenuItem()
        {
            MenuType = MenuType.EmployeeDetails;
                
        }
        public MenuType MenuType { get; set; }
    }
}
  
 