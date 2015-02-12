﻿using InsideInning.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
    public class DashboardView : ContentPage
    {
        public DashboardView()
        {
            BackgroundImage = "back";            
            RelativeLayout relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(GridStackLayouts(), Constraint.Constant(0), Constraint.Constant(0),
                                   Constraint.RelativeToParent(parent =>
                                   {
                                       return parent.Width;
                                   }),
                                   Constraint.RelativeToParent(parent =>
                                   {
                                       return parent.Height;
                                   }));
            relativeLayout.Children.Add(CreateButtonForCalendar("Calendar View", "Calendar128.png"),
                                  Constraint.Constant(120),
                                  Constraint.Constant(240));
            this.Content = MainLayouts();
        }
        private Grid GenGrid()
        {
            var grid = new Grid();
            grid.Children.Add(CreateButtonFor("Notifications", "Notify128.png", "1"), 0, 0);
            grid.Children.Add(CreateButtonFor("Leave Balance", "Balance128.png", "2"), 1, 0);
            return grid;
        }
        private Grid GenLowerGrid()
        {
            var grid = new Grid();
            grid.Children.Add(CreateButtonFor("Employee Details", "Employee128.png", "3"), 0, 0);
            grid.Children.Add(CreateButtonFor("Leave Details", "NotePad128.png", "4"), 1, 0);
            return grid;
        }
        public View CreateButtonFor(string propertyName, string imgSrc, string _id)
        {
            Button iiButton = new Button
            {
                Image = imgSrc,
                ClassId = _id,
                Text=propertyName,
                BorderColor=Color.White.ToFormsColor(),
                BorderWidth=1,
                
                TextColor = Color.White.ToFormsColor(),
                BackgroundColor =Xamarin.Forms.Color.Transparent,
                //Text = propertyName,
                HeightRequest = 50
            };
            
            iiButton.Clicked += DashboardBtn_Clicked;
            return iiButton;
        }
        void DashboardBtn_Clicked(object sender, EventArgs e)
        {
            string id = ((Button)sender).ClassId;
            switch (id)
            {
                case "1":
                    this.Navigation.PushAsync(new NotificationPage());
                    break;
                case "2":
                    this.Navigation.PushAsync(new EmployeeListPage());
                    break;
                case "3":
                    this.Navigation.PushAsync(new EmployeeDetailsPage());
                    break;
                case "4":
                    this.Navigation.PushAsync(new LeaveRequestPage());
                    break;
                case "5":
                    this.Navigation.PushAsync(new LeaveRequestPage());
                    break;
                default:
                    break;
            }
        }
        public View CreateButtonForCalendar(string propertyName, string imgSrc)
        {
            Button iiCalButton = new Button
           {
               Image = (FileImageSource)ImageSource.FromFile(imgSrc),
               TextColor = Color.White.ToFormsColor(),
               FontAttributes = FontAttributes.Italic,
               BackgroundColor = Helper.Color.DarkBlue.ToFormsColor(),
               HorizontalOptions = LayoutOptions.CenterAndExpand,
               HeightRequest = 130,
               WidthRequest = 130
           };

            return iiCalButton;
        }
        public StackLayout GridStackLayouts()
        {
            var _gridLayout = new StackLayout
            {
                BackgroundColor = Helper.Color.LightGray.ToFormsColor(),
                Padding = new Thickness(20, 20, 20, 20),
                Spacing=20,
                Children = { 
                    GenGrid(),
                	GenLowerGrid()
				}
            };
            return _gridLayout;
        }
        public StackLayout MainLayouts()
        {
            var _gridLayout = new StackLayout
            {
                Padding = new Thickness(20, 70, 20, 20),
                Spacing = 30,
                Children = { CreateButtonFor("Notification", "notify.png", "1"),
                    CreateButtonFor("ii Employee List", "leaves.png", "2"),
                CreateButtonFor("Emplyee Details", "persons.png", "3"),
                CreateButtonFor("Leave Request", "summary.png", "4"),
                CreateButtonFor("Calender", "Calendar.png", "5"),
                }
            };

            return _gridLayout;
            
        }
    }
}
