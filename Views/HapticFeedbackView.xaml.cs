using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class HapticFeedbackView : ContentPage
    {
        public HapticFeedbackView()
        {
            InitializeComponent();
            BindingContext = new HapticFeedbackViewModel();
        }
    }
}
