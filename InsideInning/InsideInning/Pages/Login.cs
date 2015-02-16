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
        public View CreateButtonFor(string propertyName, string imgSrc, string _id)
        {
            Button iiButton = new Button
            {
                Image = imgSrc,
                ClassId = _id,
                Text = propertyName,
                BorderColor = Color.White.ToFormsColor(),
                BorderWidth = 1,

                TextColor = Color.White.ToFormsColor(),
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                //Text = propertyName,
                HeightRequest = 50
            };

            iiButton.Clicked += iiButton_Clicked;
            return iiButton;
        }
        void iiButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DashboardView());

        }
    }
}

