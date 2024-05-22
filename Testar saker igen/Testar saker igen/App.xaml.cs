using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testar_saker_igen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(PrefabsPage), typeof(PrefabsPage));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
