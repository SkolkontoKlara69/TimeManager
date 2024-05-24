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

        public PrefabsPage(MainPage mainPage)
        {
            InitializeComponent(); 
            _mainPage = mainPage;
        }

        private void PrefabButton_Clicked(object sender, EventArgs e)
        {
            var prefabEntry = new Entry
            {

            };
        }

        public void AddTaskToPrefabs(string taskNameString, double taskTimeLength, Color taskColor)
        {

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

            var flexLayout = new FlexLayout{
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.SpaceBetween,
                AlignItems = FlexAlignItems.Center,
                BackgroundColor = taskColor,
                Padding = 10,
            };

            stackLayout.Children.Add(flexLayout);

            var taskLengthLabel = new Label
            {
                Text = taskTimeLength.ToString() + " min",
                FontSize = 18,
                TextColor = Color.White,
            };

            var timePicker = new TimePicker
            {
                TextColor = Color.White,
                //x:Name = startTimeEntry
            };

            var button = new Button
            {
                Text = "Add prefab",
                BackgroundColor = Color.FromHex("#FCE3F0"),
            };

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