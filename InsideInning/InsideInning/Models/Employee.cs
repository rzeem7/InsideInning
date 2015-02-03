using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning
{
   public class Employee : BaseModel
    {    

        #region Full Property

        private string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged("FirstName"); }
        }

        private string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; OnPropertyChanged("LastName"); }
        }

        private string _emailAddress = string.Empty;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; OnPropertyChanged("EmailAddress"); }
        }


        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        private string _employeeType = string.Empty;
        public string EmployeeType
        {
            get { return _employeeType; }
            set { _employeeType = value; OnPropertyChanged("EmployeeType"); }
        }

        private string _isActive = string.Empty;
        public string IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged("IsActive"); }
        }

        #endregion
    }
}
