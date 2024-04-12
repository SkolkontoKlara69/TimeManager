using System.ComponentModel;
using TimeManager.ViewModels;
using Xamarin.Forms;

namespace TimeManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}