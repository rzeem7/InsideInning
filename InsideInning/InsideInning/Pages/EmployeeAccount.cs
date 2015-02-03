using InsideInning.Helper;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class EmployeeAccount : ContentPage
    {
        private EmployeeViewModel ViewModel
        {
            get { return new EmployeeViewModel(); } //Type cast BindingContex as HomeViewModel to access binded properties
        }

        public EmployeeAccount()
        {
            BindingContext = new Employee();

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.Blue.ToFormsColor(),
                Children = 
                {
                    new Image{Source="index.jpg",Aspect=Aspect.Fill},
                    GenGrid(),
                    {iiControls.CreateEntryFor("EmailAddress",Color.White)},
                    {iiControls.CreateEntryFor("Password",Color.White,true)},
                   // {iiControls.CreateEntryFor("ConfirmPassword",Color.White,true)},
                    GenGridForSwitch(),
                    new Button
                    {
                        Text="Submit",TextColor=Color.White.ToFormsColor(),BackgroundColor=Color.Gray.ToFormsColor(),BorderWidth=1,HorizontalOptions=LayoutOptions.Center,TranslationY=40,
                        HeightRequest=40,
                        Command=ViewModel.AddUpdateCommand, CommandParameter=(Employee)BindingContext
                    }                   
                }
            };
        }
        private Grid GenGrid()
        {
            var grid = new Grid();
            grid.Children.Add(iiControls.CreateEntryFor("FirstName", Color.White), 0, 0);
            grid.Children.Add(iiControls.CreateEntryFor("LastName", Color.White), 1, 0);
            return grid;
        }
        private Grid GenGridForSwitch()
        {
            var _switchGrid = new Grid();
            _switchGrid.Children.Add(new Label { Text = "IsAdmin", TextColor = Color.White.ToFormsColor(), HorizontalOptions = LayoutOptions.Start, TranslationX = 70, TranslationY = 5 }, 0, 0);
            _switchGrid.Children.Add(new Switch { HorizontalOptions = LayoutOptions.Start  }, 1, 0);
            _switchGrid.Children.Add(new Label { Text = "IsActive", TextColor = Color.White.ToFormsColor(), HorizontalOptions = LayoutOptions.Start, TranslationX = 70, TranslationY = 5 }, 0, 1);
            _switchGrid.Children.Add(new Switch { HorizontalOptions = LayoutOptions.Start }, 1, 1);
            return _switchGrid;
        }
    }
}
