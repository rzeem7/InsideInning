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
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
               // Padding = new Thickness(100, 100, 100, 100),
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
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(30, 30, 30, 30),
                Spacing = 10,
                BackgroundColor = Color.Green.ToFormsColor(),
                Children = 
                {
                        CreateEntryFor("Username",Color.iiTextColor,"5"),
                        CreateEntryFor("Password",Color.iiTextColor, "6", true),
                        CreateButtonFor("Login"),                             
                }
            };

            return layout;
        }
        public static View CreateEntryFor(string propertyName, Color color, string id = "", bool IsPassword = false)
        {
            iiTextBox iiEditTextBox = new iiTextBox
            {
                TextColor = color.ToFormsColor(),
                IsPassword = IsPassword,
                Placeholder = propertyName,
                BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,
                TranslationY = 2,
                WidthRequest=200,
            };
            return iiEditTextBox;
        }
        public Button CreateButtonFor(string propertyName)
        {
            Button iiButton = new Button
            {
                Text = propertyName,
                TextColor = Color.White.ToFormsColor(),
                BackgroundColor = Color.Lime.ToFormsColor(),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest=40,
                FontSize=16,
                Command = ViewModel.LoginCommand,
            };

            return iiButton;
        }
        void iiButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DashboardViewPage());
        }
    }
}

