using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class iiEmployeeList : ContentPage
    {
        private EmployeeViewModel ViewModel
        {
            get { return new EmployeeViewModel(); } //Type cast BindingContex as HomeViewModel to access binded properties
        }
        ListView _iiEmpList = null;
        public iiEmployeeList()
        {
            ViewModel.LoadAllEmployees.Execute(null);
            _iiEmpList = new ListView()
            {
                BackgroundColor=Color.Red,
                ItemTemplate = new DataTemplate(typeof(EmployeeViewCell))
            };
            Content = new StackLayout
            {
                Children = {
					_iiEmpList
				}
            };

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _iiEmpList.ItemsSource = ViewModel.EmployeeList;
        }
    }

    class EmployeeViewCell : ViewCell
    {
        public EmployeeViewCell()
        {
            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "FirstName");
            var Designation = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
               
            };
            Designation.SetBinding(Label.TextProperty, "EmailAddress");

            var nameLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel, Designation }
            };
            View = nameLayout;
        }
    }
    
}
