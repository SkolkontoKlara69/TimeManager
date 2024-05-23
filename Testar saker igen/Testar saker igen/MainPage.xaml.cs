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

        }

        async void SettingsButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new SettingsPage());
        }


        async void TaskButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new AddTaskPage(this)); //Skickar med vilken mainpage som addtaskPage behöver
        }
    

        async void PrefabButton_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PrefabsPage());
        }

        public void AddTaskToAbsoluteLayout(string taskNameString, double taskTimeLength, TimeSpan taskStartTime, Color color)
        {

            var taskFrame = new Frame
            {
                BackgroundColor = color,
                CornerRadius = 10,
                HasShadow = true,
                Margin = 0,
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

            //Placerar båda labels i flex och sedan den flexlayouten i framen
            flexLayout.Children.Add(taskName);
            flexLayout.Children.Add(taskLength);
            taskFrame.Content = flexLayout;



           //Här bestäms höjden som är proportionerlig till hela scrollviewn med timmar, därför görs tasktimelength om till timmar för att delas med 24 så att det är samma procentuella höjd som en timme i scrollviewn
            double frameHeight = taskTimeLength / (60.00 * 24.00);

            //Här bestäms den propertionerliga Ypositionen, där den först beräknar vilken timme som den ska placeras vid, men sedan hur mycket den ska offsettas (eftersom vid 0 ska den inte offsettas alls och vid 1 ska den offsettas med hela höjden. Vid 0.5 kommer den att vara centrerad och behöva offsettas med en halv frameheight.)
            double frameYPosition = (taskStartTime.TotalMinutes / (24.0 * 60.0)) + (frameHeight * (taskStartTime.TotalMinutes / (24.0 * 60.0)));

            //Först definieras det att framen 
            AbsoluteLayout.SetLayoutFlags(taskFrame, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.SizeProportional);
            AbsoluteLayout.SetLayoutBounds(taskFrame, new Rectangle(0.6, frameYPosition, 0.7, frameHeight));

            // Hittar AbsoluteLayout
            var absoluteLayout = this.FindByName<AbsoluteLayout>("AbsoluteLayoutScroll");

            if (absoluteLayout == null)
            {
                DisplayAlert("Fel", "Hittade inte AbsoluteLayoutScroll", "OK");
            }
            else
            {
                absoluteLayout.Children.Add(taskFrame);
            }


            absoluteLayout.Children.Add(taskFrame);
        }
    }
}
