using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InsideInning.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public EmployeeViewModel()
        {

        }

        private string firstname = string.Empty;
        public const string FirstNamePropertyName = "FirstName";
        public string FirstName
        {
            get { return firstname; }
            set { SetProperty(ref firstname, value, FirstNamePropertyName); }
        }

        private string lastname = string.Empty;
        public const string LastNamePropertyName = "LastName";
        public string LastName
        {
            get { return lastname; }
            set { SetProperty(ref lastname, value, LastNamePropertyName); }
        }

        private string emailAddress = string.Empty;
        public const string EmailAddressPropertyName = "EmailAddress";
        public string EmailAddress
        {
            get { return emailAddress; }
            set { SetProperty(ref emailAddress, value, EmailAddressPropertyName); }
        }


        private string password = string.Empty;
        public const string PasswordPropertyName = "Password";
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value, PasswordPropertyName); }
        }

        private string employeeType = string.Empty;
        public const string EmployeeTypePropertyName = "EmployeeType";
        public string EmployeeType
        {
            get { return employeeType; }
            set { SetProperty(ref employeeType, value, EmployeeTypePropertyName); }
        }

        private string isActive = string.Empty;
        public const string IsActivePropertyName = "IsActive";
        public string IsActive
        {
            get { return isActive; }
            set { SetProperty(ref isActive, value, IsActivePropertyName); }
        }
    }
}
