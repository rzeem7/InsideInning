using InsideInning.Pages;
using InsideInning.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		INavigation iiNavigation;


        //test : RZEE
        public ObservableCollection<string> Greetings { get; set; }

		public LoginViewModel(INavigation navigation)
		{
			this.iiNavigation = navigation;
            EmpViewModel = new EmployeeViewModel();

            //
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<LoginPageView>(this, "Hi", (sender) =>
            {
                Greetings.Add("Hi");
            });

            MessagingCenter.Subscribe<LoginPageView, string>(this, "Hi", (sender, arg) =>
            {
                Greetings.Add("Hi " + arg);
            });
		}

		#region Employee

		private Employee _employee;

		public Employee EployeeInfo
		{
			get { return _employee; }
			set { _employee = value; }
		}


		#endregion

		#region Login Command

		private Command loginCommand;
        private Command logoutCommand;

		public Command LoginCommand
		{
			get
			{
				return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
			}
		}
        public Command LogoutCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new Command(async () => await ExecuteLogoutCommand()));
            }
        }

		private async Task ExecuteLoginCommand()
		{
			try
			{
				if (!IsNetworkConnected) //Have to remove !
				{
                    await ServiceHandler.PostDataAsync<Employee, string>("", "").ContinueWith(t =>
					{
                        NavigationToPage(t);
					});
				}
				else
				{
					//TODO : login locally forn database
                    //NavigationToPage(null);

                    MessagingCenter.Send<LoginPageView>(new LoginPageView(), "Hi");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occurred : {0}", ex.Message);
			}
		}

        private void NavigationToPage(Task<Employee> t)
        {
            if (t!= null  && t.Result.IsAdmin)
            {
                iiNavigation.PushModalAsync(new HomeViewPage(this), true);
            }
            else
            {
                //TODO : We'll remove it on fly code
                iiNavigation.PushModalAsync(new HomeViewPage(this), true);

                //var navPage=new NavigationPage(new DashboardViewPage(this)) 
                //{
                //    BarBackgroundColor=Xamarin.Forms.Color.Blue

                //};
                //iiNavigation.PushModalAsync(navPage, true);

            }
        }
        private async Task ExecuteLogoutCommand()
        {
            try
            {
                await iiNavigation.PushModalAsync(new LoginPageView(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred : {0}", ex.Message);
            }
        }

		#endregion


        //TODO : Have to remove
        public EmployeeViewModel EmpViewModel { get; set; }
	}
}
