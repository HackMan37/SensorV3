using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class DeviceInformationView : ContentPage
    {
        public DeviceInformationView()
        {
            InitializeComponent();
            BindingContext = new DeviceInformationViewModel();
        }
    }
}
