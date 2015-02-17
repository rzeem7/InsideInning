using InsideInning.Models;
using InsideInning.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using InsideInning.Service;
using InsideInning.Helpers;


namespace InsideInning.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        #region Constructor

        public EmployeeViewModel()
        {
            App.DataBase.CreateTables<Employee>();
            App.DataBase.CreateTables<EmployeeDetails>();
            _employeeList = new ObservableCollection<Employee>();
            _employeeDetail = new EmployeeDetails();
        }

        #endregion

        #region Peoperties

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; OnPropertyChanged("EmployeeInfo"); }
        }

        private ObservableCollection<Employee> _employeeList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return _employeeList; }
            set { _employeeList = value; OnPropertyChanged("EmployeeList"); }
        }

        #endregion

        #region Add Update Delete Commands

        //Save/Update
        //Delete
        //Search

        private Command addUpdateCommand;

        /// <summary>
        /// Command to Save/Update items
        /// </summary>
        public Command AddUpdateCommand
        {
            get
            {
                return addUpdateCommand ?? (addUpdateCommand = new Command(async (param) => await ExecuteAddUpdateCommand(param)));
            }
        }

        private async Task ExecuteAddUpdateCommand(object param)
        {
            try
            {
                EmployeeInfo = (Employee)param;
                if (EmployeeInfo == null)
                    return;

                if (IsNetworkConnected)
                {
                    await ServiceHandler.PostDataAsync<int, Employee>(EmployeeInfo, Constants.Employee);
                }
                else
                {
                    int id = App.DataBase.SaveItem<Employee>(EmployeeInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
                return;
            }
        }

        private Command _LoadAllEmployees;

        public Command LoadAllEmployees
        {
            get
            {
                return _LoadAllEmployees ?? (_LoadAllEmployees = new Command(async () => await ExecuteLoadCommand()));
            }
        }

        private async Task ExecuteLoadCommand()
        {
            try
            {
                IsBusy = true;

                if (IsNetworkConnected)
                {
                    await ServiceHandler.ProcessRequestAsync<Employee>(Constants.Employee).ContinueWith(t =>
                    {
                        if (t.Result != null && t.Result.Count > 0)
                        {

                            Device.BeginInvokeOnMainThread(() =>
                            {
                                EmployeeList = t.Result;
                            });

                        }
                    }); //Server Call
                    IsBusy = false;
                }
                else
                {
                    _employeeList = App.DataBase.GetItems<Employee>(); //From Local DB
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
            }
        }

        #endregion

        #region EmployeeDetails Properties

        private EmployeeDetails _employeeDetail;

        public EmployeeDetails EmployeeDetail
        {
            get { return _employeeDetail; }
            set { _employeeDetail = value; OnPropertyChanged("EmployeeDetail"); }
        }

        #endregion

        #region EmployeeDetails Command

        private Command _addUpdateCommand;
        public Command AddUpdateEmployeeDetailsCommand
        {
            get
            {
                return _addUpdateCommand ?? (_addUpdateCommand = new Command(async (param) => await ExecuteAddUpdateEmployeeDetailsCommand(param)));
            }
        }

        private async Task ExecuteAddUpdateEmployeeDetailsCommand(object param)
        {
            try
            {
                EmployeeDetail = (EmployeeDetails)param;
                if (EmployeeDetail == null)
                    return;

                if (IsNetworkConnected)
                {
                    await ServiceHandler.PostDataAsync<int, EmployeeDetails>(EmployeeDetail, Constants.EmployeeDetails);
                }
                else
                {
                    int id = App.DataBase.SaveItem<EmployeeDetails>(EmployeeDetail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
                return;
            }
        }

        private Command _loadEmpDetail;

        public Command LoadEmpDetail
        {
            get
            {
                return _loadEmpDetail ?? (_loadEmpDetail = new Command(async (param) => await ExecuteLoadEmpDataCommand(param)));
            }
        }

        private async Task ExecuteLoadEmpDataCommand(object param)
        {
            try
            {
                var _empID = (Int32)param;

                if (IsNetworkConnected)
                {
                    await ServiceHandler.ProcessRequestAsync<EmployeeDetails>(string.Format("{0}{1}", Constants.EmployeeDetails, _empID)).ContinueWith(t =>
                    {
                        if (t.Result.Count == 1)
                        {
                            _employeeDetail = t.Result[0];
                        }
                    }); //Server Call
                }
                else
                {
                    _employeeDetail = App.DataBase.GetItem<EmployeeDetails>(_empID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During getting the Record {0}", ex.Message);
            }
        }

        #endregion
    }
}
