using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public class MailSummary : BaseModel
    {

        #region Public Properties
        public Int32 MailID { get; set; }

        public Int32 ToEmployeeID { get; set; }

        public Int32 CCEmployeeID { get; set; }

        public Int32 FromEmployeeID { get; set; }

        public String MessageBody { get; set; }

        public String MailSubject { get; set; }

     #endregion
    }
}
