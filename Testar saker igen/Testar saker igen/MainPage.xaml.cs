using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testar_saker_igen
{
    public partial class MainPage : ContentPage 
    {
        public MainPage()
        {
            InitializeComponent();

            AddFrameToAbsoluteLayout("Ta studenten", 300, new TimeSpan(2, 0, 0), Color.HotPink);

            AddFrameToAbsoluteLayout("Gå hem", 60, new TimeSpan(10, 0, 0), Color.Green);
        /*
            for (int i = 0; i < 24; i++)
            {
                AddFrameToAbsoluteLayout("Gå hem", 10, new TimeSpan(i, 0, 0), Color.FromRgb(10*i,10*i,10*i));
            }
        */
        }

        async void SettingsButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SettingsPage());
        }


        async void TaskButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }

        async void PrefabButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PrefabsPage());
        }

        private void AddFrameToAbsoluteLayout(string taskNameString, double taskTimeLength,TimeSpan taskStartTime, Color color)
        {
            
            var newFrame = new Frame
            {
                BackgroundColor = color,
                CornerRadius = 10,
                HasShadow = true
            };
        
            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.SpaceBetween,
                Margin = new Thickness(0),
            };

            var taskName = new Label
            {
                Text = taskNameString,
                TextColor = Color.White,
                FontSize = 20,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                Padding = 0,
            };

            var taskLength = new Label
            {
                Text = taskTimeLength.ToString(),
                // Bara test Text = taskStartTime.Hours.ToString(),
                TextColor = Color.White,
                FontSize = 12,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End
            };

            flexLayout.Children.Add(taskName);
            flexLayout.Children.Add(taskLength);

            newFrame.Content = flexLayout;



            // Placerar den i AbsoluteLayout med samma LayoutBounds och LayoutFlags som i XAML
            double frameHeight = taskTimeLength / (60.00 * 24.00);
            double frameYPosition = 0;

            if (taskStartTime.TotalMinutes >= taskTimeLength)
            {
                frameYPosition = (taskStartTime.TotalMinutes / (24.0 * 60.0)) + frameHeight / 2; //(taskStartTime.Hours) / 24.00 + taskStartTime.Minutes/(24.00*60.00) + frameHeight;
            }
            else
            {
                frameYPosition = (taskStartTime.TotalMinutes / (24.0 * 60.0));
            }
                AbsoluteLayout.SetLayoutFlags(newFrame, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(newFrame, new Rectangle(0.6, frameYPosition, 0.7, frameHeight));

            // Hittar AbsoluteLayout
            var absoluteLayout = this.FindByName<AbsoluteLayout>("AbsoluteLayoutScroll");

        if (absoluteLayout == null)
        {
            DisplayAlert("Fel", "Hittade inte AbsoluteLayoutScroll", "OK");
        }
        else
        {
            absoluteLayout.Children.Add(newFrame);
        }


        absoluteLayout.Children.Add(newFrame);
        }
    }
}
