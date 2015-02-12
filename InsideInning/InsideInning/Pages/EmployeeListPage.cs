using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using ImageCircle.Forms.Plugin.Abstractions;
namespace InsideInning.Pages
{
    public class EmployeeListPage : ContentPage
    {
        private EmployeeViewModel ViewModel
        {
            get;
            set;//Type cast BindingContex as HomeViewModel to access binded properties
        }
        ListView _iiEmpList = null;
        public EmployeeListPage()
        {
            ViewModel = ViewModel ?? new EmployeeViewModel();
            ViewModel.LoadAllEmployees.Execute(null);
            _iiEmpList = new iiListView()
            {
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

    #region Custom View cell
    /// <summary>
    /// This class is a ViewCell that will be displayed for each Employee Cell.
    /// </summary>
    class EmployeeViewCell : ViewCell
    {
        public EmployeeViewCell()
        {
            var EmpImage = new CircleImage()
            {
                HorizontalOptions = LayoutOptions.Start,
                BorderThickness=5,
                Source = "Dummy.jpg",
                BorderColor=Color.White,
                Aspect=Aspect.Fill,
            };
            //EmpImage.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
            EmpImage.WidthRequest = EmpImage.HeightRequest = 60;

            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            nameLabel.FontSize = 15;
            nameLabel.SetBinding(Label.TextProperty, "FirstName");

            var Designation = new Label
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            Designation.FontSize = 15;
            Designation.SetBinding(Label.TextProperty, "EmailAddress");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(0,1.5,0,1.5),
                HeightRequest=10,
                Spacing=0,
                Children = {
                    EmpImage,
                    //new Image{Source="index.jpg",HeightRequest=50,WidthRequest=50},
					new StackLayout {
                        Spacing=0,
						Orientation = StackOrientation.Vertical,
                        VerticalOptions=LayoutOptions.Start,
                        Padding=0,
						Children = { nameLabel, Designation }
					},
					
				}
            };
            
        }
    }
    #endregion
    
}
