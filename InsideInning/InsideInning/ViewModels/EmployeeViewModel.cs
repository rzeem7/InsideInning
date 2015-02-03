using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public EmployeeViewModel()
        {

        }

        #region Peoperties

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; OnPropertyChanged("EmployeeDetail"); }
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
                return addUpdateCommand ?? (addUpdateCommand = new Command(async () => await ExecuteAddUpdateCommand()));
            }
        }

        private Task ExecuteAddUpdateCommand()
        {
            try
            {
                if (EmployeeInfo == null)
                    return null;

                int id = App.DataBase.SaveItem<Employee>(EmployeeInfo);
                Console.WriteLine("Fetched ID {0}", id);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occured During Save Record {0}", ex.Message);
                return null;
            }
        }

        #endregion

    }
}
