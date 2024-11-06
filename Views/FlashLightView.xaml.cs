using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class FlashLightView : ContentPage
    {
        public FlashLightView()
        {
            InitializeComponent();
            BindingContext = new FlashLightViewModel();
        }
    }
}
