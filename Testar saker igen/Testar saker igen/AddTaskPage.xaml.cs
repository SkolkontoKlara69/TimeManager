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
    public partial class AddTaskPage : ContentPage
    {
        private MainPage _mainPage;

        public AddTaskPage(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            // Använd användarens inmatning för att skapa en ny uppgift
            string taskName = taskNameEntry.Text;
            double taskLength = double.Parse(taskLengthEntry.Text);
            TimeSpan taskStartTime = taskStartTimePicker.Time;
            Color color = Color.FromHex(ColorEntry.Text);

            // Anropa MainPage's AddFrameToAbsoluteLayout-metod
            _mainPage.AddFrameToAbsoluteLayout(taskName, taskLength, taskStartTime, color);

            // Gå tillbaka till MainPage
            Navigation.PopAsync();
        }


    }
}