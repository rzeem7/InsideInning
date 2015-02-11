using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class BalanceLeavePage : BaseView
    {
        public BalanceLeavePage()
        {
            BackgroundImage = "back";
            Content = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 70, 20, 20),
                Spacing=20,
                Children = 
                {
                  {(CreateListFor("Laeve Type"))},
                    GenCalGrid(),
                }
            };
        }
        private Grid GenCalGrid()
        {
            var grid = new Grid()
            {
                ColumnSpacing=2,
                RowSpacing=2,
            };

            grid.Children.Add(CreateLabelFor("Leave Type",LayoutOptions.Start,"2"), 0, 0);
            grid.Children.Add(CreateLabelFor("Total", Color.Purple, LayoutOptions.Start,"",true), 1, 0);
            grid.Children.Add(CreateLabelFor("Used", Color.Purple, LayoutOptions.Start,"",true), 2, 0);
            grid.Children.Add(CreateLabelFor("Pending", LayoutOptions.Start, "3"), 3, 0);

            grid.Children.Add(CreateLabelFor("Casual Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 1);

            grid.Children.Add(CreateLabelFor("Medical Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 2);

            grid.Children.Add(CreateLabelFor("Paid Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 3);

            return grid;
        }
        #region Custom Label
        public View CreateLabelFor(string propertyName,Color color, LayoutOptions layout, string id = "",bool isHeader=false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = isHeader?  Color.White.ToFormsColor():Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest=130,
                FontSize = 10,
                ClassId = id,
                XAlign=TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor=color.ToFormsColor(),
            };
            return iiLabel;
        }
        public View CreateLabelFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 120,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            return iiLabel;
        }
        #endregion
        #region Custom ListView

        public static View CreateListFor(string propertyName)
        {
           
            var listView = new ListView();
            listView.VerticalOptions = LayoutOptions.Center;
            listView.ItemsSource = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            listView.ItemTapped += async (sender, e) =>
            {
                Console.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null;
            };
            var OuterLayout = new StackLayout()
            {
                HorizontalOptions=LayoutOptions.Center,
                Padding=new Thickness(50,0,50,0),
                Children =
                {
                    listView
                }
            };
            return OuterLayout;
        }

        #endregion
    }
}
