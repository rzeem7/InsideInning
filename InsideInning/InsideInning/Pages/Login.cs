using InsideInning.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
   public class Login: BaseView
    {
        public Login()
        {
            BindingContext = new Employee();
            BackgroundImage = "back";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(30, 180, 30, 100),             
                Children = 
                {      
                    CreateStackfor(),
                }
            };
        }
        private StackLayout CreateStackfor()
        {
            var layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(30,30, 30, 30),
                Spacing = 10,
                BackgroundColor=Color.Gray.ToFormsColor(),

                Children = 
                {
                    {iiControls.CreateEntryFor("Username",Color.iiTextColor,"5")},
                    {iiControls.CreateEntryFor("Password",Color.iiTextColor, "6", true)},
                    new Button
                    {
                        Text="Login",TextColor=Color.White.ToFormsColor(),BackgroundColor=Color.Lime.ToFormsColor(),BorderWidth=1,HorizontalOptions=LayoutOptions.Center,
                        HeightRequest=40,
                   }                   
                }
            };
            return layout;
        }

    }
}

