using InsideInning.Helper;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
    public class LoginPageView : BaseViewPage
    {

        public LoginViewModel ViewModel
        {
            get
            {
                return BindingContext as LoginViewModel;
            }
        }

        public LoginPageView()
        {
            BindingContext = new LoginViewModel(this.Navigation);
            BackgroundImage = "back";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(5, 180, 0, 100),
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
                Padding = new Thickness(70, 30, 70, 30),
                Spacing = 10,
                BackgroundColor = Color.Gray.ToFormsColor(),
                Children = 
                {
                        iiControls.CreateEntryFor("Username",Color.iiTextColor,"5"),
                        iiControls.CreateEntryFor("Password",Color.iiTextColor, "6", true),
                    new Button
                    {
                        Text="Login",TextColor=Color.White.ToFormsColor(),
                        Image="Icon",
                        BackgroundColor=Color.Lime.ToFormsColor(),
                        BorderWidth=1,
                        HorizontalOptions=LayoutOptions.FillAndExpand,
                        Command= ViewModel.LoginCommand
                    }                   
                }
            };

            return layout;
        }
        public Button CreateButtonFor(string propertyName, string imgSrc, string _id)
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
                HeightRequest = 50,
                Command = ViewModel.LoginCommand
            };

            return iiButton;
        }
        void iiButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DashboardViewPage());
        }
    }
}

