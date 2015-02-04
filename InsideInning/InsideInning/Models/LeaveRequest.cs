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

        private string _leavetype = string.Empty;
        public string LeaveType
        {
            get { return _leavetype; }
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

        
     #endregion
        
    }
}
