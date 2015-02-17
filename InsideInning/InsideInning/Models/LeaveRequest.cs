using InsideInning.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Models
{
    public class LeaveRequest : BaseModel
    {

        #region Public Properties

        private DateTime _fromdate = DateTime.Now;
        public DateTime FromDate
        {
            get { return _fromdate; }
            set { _fromdate = value; OnPropertyChanged("FromDate"); }
        }

        private DateTime _todate = DateTime.Now;
        public DateTime ToDate
        {
            get { return _todate; }
            set { _todate = value; OnPropertyChanged("ToDate"); }
        }

        private bool _leavetype ;
        public bool LeaveType
        {
            get { return true; }
            set { _leavetype = value; OnPropertyChanged("LeaveType"); }
        }

        private string _to = string.Empty;
        public string To
        {
            get { return _to; }
            set { _to = value; OnPropertyChanged("To"); }
        }
        private string _notes = string.Empty;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged("Notes"); }
        }

        private int _totalcasualleave;

        public int TotalCasualLeave
        {
            get { return 1; }
            set { _totalcasualleave = value; OnPropertyChanged("TotalCasualLeave"); }
        }

        private int _TotalSickLeave;

        public int TotalSickLeave
        {
            get { return 1; }
            set { _TotalSickLeave = value; OnPropertyChanged("TotalSickLeave"); }
        }

        private bool _IsApproved;

        public bool IsApproved
        {
            get { return true; }
            set { _IsApproved = value;OnPropertyChanged("IsApproved"); }
        }

        private string _ApprovedByID;

        public string ApprovedByID
        {
            get { return _ApprovedByID; }
            set { _ApprovedByID = value;OnPropertyChanged("ApprovedByID"); }
        }
        private DateTime _ApprovedOn;

        public DateTime ApprovedOn
        {
            get { return System.DateTime.Now; }
            set { _ApprovedOn = value;OnPropertyChanged("ApprovedOn"); }
        }
        private int _ApprovedDays;

        public int ApprovedDays
        {
            get { return 1; }
            set { _ApprovedDays = value;OnPropertyChanged("ApprovedDays"); }
        }
        private int _EmployeeID;

        public int EmployeeID
        {
            get { return 1; }
            set { _EmployeeID = value; OnPropertyChanged("EmployeeID");}
        }
        
        
     #endregion
        
    }
}
