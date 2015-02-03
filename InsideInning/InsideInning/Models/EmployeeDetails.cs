using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public class EmployeeDetails : BaseModel
    {
        #region Public Properties
        public Int32 EmployeeDetailsID { get; set; }

        public String EmpProfileImage { get; set; }

        public Int32 EmployeeID { get; set; }

        public String gender { get; set; }

        public String MaritalStatus { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfAniversary { get; set; }

        public Int32 ContactNumber { get; set; }

        public Int32 Landline { get; set; }

        public String CompanyProfile { get; set; }

        public DateTime JoinningDate { get; set; }

        public Boolean IsActive { get; set; }

        #endregion
    }
}
