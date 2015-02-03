using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
   public class Employee : BaseModel
    {    
        #region Public Properties
      public Int32 EmployeeID{ get; set;}

      public String FirstName{ get; set;}

      public String LastName{ get; set;}

      public String EmailAddress{ get; set;}

      public String Password{ get; set;}

      public Boolean EmployeeType{ get; set;}

      public Boolean IsActive{ get; set;}

      #endregion
  }
}
