using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Testar_saker_igen
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrefabsPage : ContentPage
    {
        private MainPage _mainPage;
        private static string localTaskName;
        private static double localTaskLength;
        private static TimePicker localTimePicker;
        private static Color localTaskColor;

        public PrefabsPage(MainPage mainPage)
        {
            InitializeComponent(); 
            _mainPage = mainPage;
        }

        private void PrefabButton_Clicked(object sender, EventArgs e)
        {
            if (localTimePicker == null) {
                DisplayAlert("TimePicker saknas", "LocalTimePicker kunde inte hittas", "Ok");
            }
            else
            {
                _mainPage.AddTaskToAbsoluteLayout(localTaskName, localTaskLength, localTimePicker.Time, localTaskColor);

                Navigation.PopAsync();
            }
        }

        public void AddTaskToPrefabs(string taskNameString, double taskTimeLength, Color taskColor)
        {
            localTaskColor = taskColor;
            localTaskLength = taskTimeLength;
            localTaskName = taskNameString;

            var stackLayout = new StackLayout
            {
                Margin = 20,
            };

            var taskNameLabel = new Label
            {
                Text = taskNameString,
                FontSize = 20,
                TextColor = Color.FromHex("#291A29"),
            };

            stackLayout.Children.Add(taskNameLabel);

            //En flexlayout kan inte ha cornerradius så därför skapar jag en frame som jag lägger flexlayouten i
            var cornerRadiusFrame = new Frame
            {
                Padding = 0,
                CornerRadius = 10,
            };

            stackLayout.Children.Add(cornerRadiusFrame);

            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.SpaceBetween,
                AlignItems = FlexAlignItems.Center,
                BackgroundColor = taskColor,
                Padding = 15,
            };

            cornerRadiusFrame.Content = flexLayout;

            var taskLengthLabel = new Label
            {
                Text = taskTimeLength.ToString() + " min",
                FontSize = 18,
                TextColor = Color.White,
            };

            var timePicker = new TimePicker
            {
                TextColor = Color.White,
            };

            localTimePicker = timePicker;

            var button = new Button
            {
                Text = "Add prefab",
                BackgroundColor = Color.FromHex("#FCE3F0"),
                CornerRadius = 10,
            };

            button.Clicked += PrefabButton_Clicked;

            flexLayout.Children.Add(taskLengthLabel);
            flexLayout.Children.Add(timePicker);
            flexLayout.Children.Add(button);

            // Hittar AbsoluteLayout
            var prefabsStackLayout = this.FindByName<StackLayout>("HeaderAndPrefabs");

            if (prefabsStackLayout == null)
            {
                DisplayAlert("Fel", "Hittade inte prefabsStackLayout", "OK");
            }
            else
            {
                prefabsStackLayout.Children.Add(stackLayout);
            }

        }
    }
}