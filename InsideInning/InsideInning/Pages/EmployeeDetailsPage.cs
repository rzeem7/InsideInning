using InsideInning.Helper;
using InsideInning.Models;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;
using ImageCircle.Forms.Plugin.Abstractions;
namespace InsideInning.Pages
{
    public class EmployeeDetailsPage : ContentPage
    {
        Int32 _EmployeeID;
        private EmployeeViewModel ViewModel
        {
            get;
            set;//Type cast BindingContex as HomeViewModel to access binded properties
        }
        public EmployeeDetailsPage(Int32 _id, EmployeeViewModel _viewModel)
        {
            ViewModel = _viewModel; //Passed from List or Dashboard
            _EmployeeID = _id;
            BackgroundImage = "back";
            BindingContext = ViewModel.EmployeeDetail;
            Content = new StackLayout
           {
               HorizontalOptions = LayoutOptions.FillAndExpand,
               HeightRequest = 50,
               Padding = new Thickness(30, 0, 30, 0),

               Children = 
                {
                    {CreateRealtiveLayoutFor()},
                    GenGrid(),
                    {CreateDatePickerFor("Date of birth", "DateOfBirth","1")},
                    {CreateDatePickerFor("Date of Joining", "JoinningDate","2")},
                    { iiControls.CreateEntryFor("ContactNumber",Color.White)},
                    { iiControls.CreateEntryFor("EmailAddress",Color.White)},
                    { iiControls.CreateEntryFor("Company Profile",Color.White)},
                    new Button 
                    {
                        Text= "Submit",
                        TextColor=Color.White.ToFormsColor(),
                        Command=ViewModel.AddUpdateEmployeeDetailsCommand,
                        CommandParameter=(EmployeeDetails)BindingContext,
                        HorizontalOptions=LayoutOptions.FillAndExpand
                    },
                }
           };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadEmpDetail.Execute(_EmployeeID);
        }
        private Grid GenGrid()
        {
            var grid = new Grid();
            grid.Children.Add(CreateButtonFor("Male", Color.White, LayoutOptions.End, "1"), 0, 0);
            grid.Children.Add(CreateButtonFor("Feamle", Color.White, LayoutOptions.Start, "2"), 1, 0);

            return grid;
        }
        public View CreateButtonFor(string propertyName, Color color, LayoutOptions layout, string id = "")
        {
            iiButton iiButton = new iiButton
            {
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //Image=(FileImageSource)ImageSource.FromFile(imgscr),
                TextColor = color.ToFormsColor(),
                BackgroundColor = Xamarin.Forms.Color.Transparent,

                BorderWidth = 10,
                WidthRequest = 55,
                HeightRequest = 55,
                HorizontalOptions = layout,
                ClassId = id,

            };
            //iiButton.SetBinding(Button.TextColorProperty, propertyName);
            return iiButton;
        }
        public View CreateDatePickerFor(string propertyName, string bindProperty, string id = "")
        {
            iiDatePicker iiDatePicker = new iiDatePicker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,

            };
            iiDatePicker.SetBinding(iiDatePicker.DateProperty, bindProperty);
            return iiDatePicker;
        }
        public RelativeLayout CreateRealtiveLayoutFor()
        {
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                HeightRequest = 100,

            };
            var CoverPage = new Image { Source = "back.png", };
            var CircleImage = new CircleImage { Source = "ProfileImage.png" ,BorderColor=Color.White.ToFormsColor(),BorderThickness=2};
            MainView.Children.Add(CoverPage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width; }), Constraint.Constant(80));
            MainView.Children.Add(CircleImage, Constraint.RelativeToParent(parent => { return parent.Width / 2; }),
                Constraint.RelativeToView(CoverPage, (parent, sibling) => { return sibling.Height - 10; }), Constraint.Constant(40), Constraint.Constant(40));
            return MainView;
        }
    }
}