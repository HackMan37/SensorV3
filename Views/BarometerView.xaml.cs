using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class BarometerView : ContentPage
    {
        public BarometerView()
        {
            InitializeComponent();
            BindingContext = new BarometerViewModel();
        }
    }
}