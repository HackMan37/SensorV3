using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class CurrentLocationView : ContentPage
    {
        public CurrentLocationView()
        {
            InitializeComponent();
            BindingContext = new CurrentLocationViewModel();
        }
    }
}
