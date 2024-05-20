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

            AddFrameToAbsoluteLayout("Ta studenten", 120, new TimeSpan(12,0,0), Color.HotPink);
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
                Margin = -10,
            };

            var taskName = new Label
            {
                Text = taskNameString,
                TextColor = Color.White,
                FontSize = 20,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
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
            double frameHeight = taskTimeLength / (60 * 24);
            double frameYPosition = taskStartTime.Hours / 24; //+ taskStartTime.Minutes/(24*60);
            AbsoluteLayout.SetLayoutBounds(newFrame, new Rectangle(0.6, frameYPosition, 0.7, frameHeight));
            AbsoluteLayout.SetLayoutFlags(newFrame, AbsoluteLayoutFlags.All);

            // Hittar AbsoluteLayout
            var absoluteLayout = this.FindByName<AbsoluteLayout>("AbsoluteLayoutScroll");

            absoluteLayout.Children.Add(newFrame);
        }
    }
}
