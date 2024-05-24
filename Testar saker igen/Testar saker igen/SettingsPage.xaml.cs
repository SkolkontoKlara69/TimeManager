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
    public partial class SettingsPage : ContentPage
    {
        private PrefabsPage prefabsPage_;
        public SettingsPage(PrefabsPage prefabsPage)
        {
            InitializeComponent();
            prefabsPage_ = prefabsPage;
        }

        private void AddPrefabButton_Clicked(object sender, EventArgs e)
        {
            int parsedTaskLentgh;
            string taskName = taskNameEntry.Text;

            // Använder användarens input för att skapa ett nytt task
            bool taskLengthCanBeParsed = int.TryParse(taskLengthEntry.Text, out parsedTaskLentgh);

            //Här kollas det ifall all input är valid eller inte
            if (taskNameEntry == null || string.IsNullOrWhiteSpace(taskName))
            {
                DisplayAlert("Invalid task name", "Enter a name for your task", "Ok");
            }
            else if (!taskLengthCanBeParsed || parsedTaskLentgh > (12 * 60) || parsedTaskLentgh < 5)
            {
                DisplayAlert("Invalid task length entry", "Try entering the time in minutes (a task can not be longer than 12 hours and has to be longer than 5 minutes)", "Ok");
            }
            else if (ColorEntry == null || string.IsNullOrWhiteSpace(ColorEntry.Text))
            {
                DisplayAlert("No Color entered", "Try entering a valid hexadecimal code for the color (it should start with # and be followed by 3, 6 or 8 numbers/letters", "Ok");

            }
            else if (ColorEntry.Text.First<Char>() != '#' || ColorEntry.Text.Length != 4 && ColorEntry.Text.Length != 7 && ColorEntry.Text.Length != 9) // ColorEntry.Text.Contains<Char>('G') /* Här kan kan man comparea texten så att den bara innehåller rätt siffror/bokstäver*/)
            {
                DisplayAlert("Invalid color entry", "Try entering a valid hexadecimal code for the color (it should start with # and be followed by 3, 6 or 8 numbers/letters", "Ok");

            }
            else
            {
                Color color = Color.FromHex(ColorEntry.Text);

                prefabsPage_.AddTaskToPrefabs(taskName, parsedTaskLentgh, color);

                // Går tillbaka till MainPagen
                Navigation.PopAsync();
            }
        }
    }
}