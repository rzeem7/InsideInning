using InsideInning.Helper;
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
    	public DashboardView ()
		{
            RelativeLayout relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(GridStackLayouts(), Constraint.Constant(0), Constraint.Constant(0),
                                   Constraint.RelativeToParent(parent => {
                                       return parent.Width;
                                   }),
                                   Constraint.RelativeToParent(parent => {
                                       return parent.Height;
                                   }));
            relativeLayout.Children.Add(CreateButtonForCalendar("Calendar View", "Calendar128.png"),
                                  Constraint.Constant(120),
                                  Constraint.Constant(240));
            this.Content = relativeLayout;
		}
        private Grid GenGrid()
        {
            var grid = new Grid();
            grid.Children.Add(CreateButtonFor("Notifications", "Notify128.png","1"), 0, 0);
            grid.Children.Add(CreateButtonFor("Leave Balance", "Balance128.png","2"), 1, 0);
            return grid;
        }
        private Grid GenLowerGrid()
        {
            var grid = new Grid();
            grid.Children.Add(CreateButtonFor("Employee Details", "Employee128.png","3"), 0, 0);
            grid.Children.Add(CreateButtonFor("Leave Details", "NotePad128.png","4"), 1, 0);
            return grid;
        }
        public View CreateButtonFor(string propertyName,string imgSrc,string _id)
        {
            Button iiButton = new Button
            {
                Image = (FileImageSource) ImageSource.FromFile(imgSrc),
                ClassId=_id,
                TextColor = Color.Blue.ToFormsColor(),
                FontAttributes=FontAttributes.Italic,
                BackgroundColor = Helper.Color.White.ToFormsColor(),
                //Text = propertyName,
                HeightRequest=400  
            };
            
            iiButton.Clicked += DashboardBtn_Clicked;
             return iiButton;
        }
        void DashboardBtn_Clicked(object sender, EventArgs e)
        {
            string id = ((Button)sender).ClassId;
            if (id == "1")
           {

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
                HorizontalOptions=LayoutOptions.CenterAndExpand,
                HeightRequest = 130,
                WidthRequest=130
            };
             
            return iiCalButton;
        }
        public StackLayout GridStackLayouts()
        {
            var _gridLayout = new StackLayout
            {
                BackgroundColor = Helper.Color.LightGray.ToFormsColor(),
                Padding = new Thickness(10, 10, 10, 10),
                Children = { 
                    GenGrid(),
                	GenLowerGrid()
				}
            };
            return _gridLayout;
        }
	}
}
