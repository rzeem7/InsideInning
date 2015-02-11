using InsideInning.Helpers;
using InsideInning.Models;
using InsideInning.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
    public class LeaveRequestViewModel : BaseViewModel
    {
        public LeaveRequestViewModel()
        {
            App.DataBase.CreateTables<LeaveRequest>();
        }

        #region Peoperties

        private LeaveRequest _leaveRequestInfo;
        public LeaveRequest LeaveRequestInfo
        {
            get { return _leaveRequestInfo; }
            set { _leaveRequestInfo = value; OnPropertyChanged("LeaveRequestInfo"); }
        }
        #endregion

        #region Commands
        //Save

        private Command addCommand;

        /// <summary>
        /// Command to Save Record
        /// </summary>
        /// 
        public Command AddCommand
        {
            get
            {
                return addCommand = new Command(async (param) => await ExecuteAddCommand(param));
            }
        }
        private async Task ExecuteAddCommand(object param)
        {
            try
            {
                LeaveRequestInfo = (LeaveRequest)param;
                if (LeaveRequestInfo == null)
                    return;

                //int id = App.DataBase.SaveItem<LeaveRequest>(LeaveRequestInfo);
                var dd =await ServiceHandler.PostDataAsync<int, LeaveRequest>(LeaveRequestInfo, Constants.LeaveRequest);
                Console.WriteLine("Fetched ID {0}", dd);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
                return;
            }
        }
        #endregion
    }
}