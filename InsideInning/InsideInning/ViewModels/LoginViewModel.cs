using InsideInning.Pages;
using InsideInning.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		INavigation iiNavigation;

		public LoginViewModel(INavigation navigation)
		{
			this.iiNavigation = navigation;
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

		public Command LoginCommand
		{
			get
			{
				return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
			}
		}

		private async Task ExecuteLoginCommand()
		{
			try
			{
				if (!IsNetworkConnected) //Have to remove !
				{
					await ServiceHandler.PostDataAsync<bool, String>("", "").ContinueWith(t =>
					{
						if (t.Result)
						{
							iiNavigation.PushModalAsync(new HomeViewPage(), true);
						}
					});
				}
				else
				{
					//TODO : login locally
					await iiNavigation.PushModalAsync(new HomeViewPage(), true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occurred : {0}", ex.Message);
			}
		}

		#endregion
	}
}
