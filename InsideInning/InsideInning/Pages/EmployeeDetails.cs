using InsideInning.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;
namespace InsideInning.Pages
{
    public class EmployeeDetails : ContentPage
    {
        public EmployeeDetails()
        {
            Content = new StackLayout
           {
               HorizontalOptions = LayoutOptions.FillAndExpand,
               HeightRequest = 50,
               BackgroundColor = Color.Blue.ToFormsColor(),
               Children = 
                {
                    new Image{Source="index.jpg",Aspect=Aspect.Fill},
                    GenGrid(),
                    GenCalGrid(),
                    { iiControls.CreateEntryFor("ContactNumber",Color.White)},
                    { iiControls.CreateEntryFor("EmailAddress",Color.White)},
                    { iiControls.CreateEntryFor("Company Profile",Color.White)},
                    new Button {Text= "Submit",TextColor=Color.White.ToFormsColor()},
                }
           };
        }
        private Grid GenGrid()
        {
            var grid = new Grid()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                RowSpacing=10,

                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto, },
                    new RowDefinition { Height = GridLength.Auto },

                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };
                   
            grid.Children.Add(CreateLabelFor("Gender"),1,0);
            grid.Children.Add(CreateButtonFor("Male",Color.White,LayoutOptions.End), 4, 0);
            grid.Children.Add(CreateButtonFor("Feamle", Color.White,LayoutOptions.Start), 5, 0);

            grid.Children.Add(CreateLabelFor("Marital Status"), 1, 2);
            grid.Children.Add(CreateButtonFor("Yes", Color.White, LayoutOptions.End), 4, 2);
            grid.Children.Add(CreateButtonFor("NO", Color.White, LayoutOptions.Start), 5, 2);

            return grid;
        }
        private Grid GenCalGrid()
        {
            var grid = new Grid()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                //HorizontalOptions = LayoutOptions.Center,
                //TranslationX = 10,

                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto, },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            grid.Children.Add(CreateLabelFor("Date of birth"), 1, 0);
            grid.Children.Add(CreateDatePickerFor("Date of birth"), 2, 0);

            grid.Children.Add(CreateLabelFor("Date of Anniversary"), 1, 1);
            grid.Children.Add(CreateDatePickerFor("Date of Anniversary"), 2, 1);

            grid.Children.Add(CreateLabelFor("Date of Joining"), 1, 2);
            grid.Children.Add(CreateDatePickerFor("Date of Joining"), 2, 2);

            return grid;
        }
        public View CreateLabelFor(string propertyName)
        {
            Label iiLabel = new Label
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName, 
                YAlign=TextAlignment.Center,
            };
            return iiLabel;
        }
        public View CreateDatePickerFor(string propertyName)
        {
            DatePicker iiDatePicker = new DatePicker
            {
                HorizontalOptions=LayoutOptions.Start,
                
           };
            iiDatePicker.SetBinding(DatePicker.DateProperty, propertyName);
            return iiDatePicker;
        }
        public View CreateButtonFor(string propertyName, Color color, LayoutOptions layout)
        {
            Button iiButton = new Button
            {
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = color.ToFormsColor(),
                BorderWidth=10,
                WidthRequest=20,
                HeightRequest=20,
                HorizontalOptions = layout,
                
            };
            iiButton.SetBinding(Button.TextColorProperty, propertyName);
            return iiButton;
        }
        
    }
}