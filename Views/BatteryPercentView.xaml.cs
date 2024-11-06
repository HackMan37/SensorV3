using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class BatteryPercentView : ContentPage
    {
        public BatteryPercentView()
        {
            InitializeComponent();
            BindingContext = new BatteryPercentViewModel();
        }
    }
}
