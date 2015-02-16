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
        public EmployeeViewModel()
        {
            App.DataBase.CreateTables<Employee>();
            App.DataBase.CreateTables<EmployeeDetails>();
            _employeeList = new ObservableCollection<Employee>();
        }

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

        #region Commands
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

                //int id = App.DataBase.SaveItem<Employee>(EmployeeInfo);
                var dd = await ServiceHandler.PostDataAsync<int, Employee>(EmployeeInfo, Constants.Employee);
                Console.WriteLine("Fetched ID {0}", dd);
                return;
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
                //_employeeList = App.DataBase.GetItems<Employee>(); //From Local DB
                _employeeList = await ServiceHandler.ProcessRequestAsync<Employee>(Constants.Employee); //Server Call
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
            }
        }

        #endregion

        #region EmployeeDetails Properties


        private EmployeeDetails _employeedetail;

        public EmployeeDetails EmployeeDetail
        {
            get { return _employeedetail; }
            set { _employeedetail = value; OnPropertyChanged("EmployeeDetail"); }
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

               // int id = App.DataBase.SaveItem<EmployeeDetails>(EmployeeDetail);
                var dd = await ServiceHandler.PostDataAsync<int, EmployeeDetails>(EmployeeDetail, Constants.EmployeeDetails);

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
