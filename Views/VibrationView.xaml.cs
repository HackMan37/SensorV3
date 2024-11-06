using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class VibrationView : ContentPage
    {
        public VibrationView()
        {
            InitializeComponent();
            BindingContext = new VibrationViewModel();
        }
    }
}
