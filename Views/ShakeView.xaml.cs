using SensorV3.ViewModels;

namespace SensorV3.Views
{
    public partial class ShakeView : ContentPage
    {
        public ShakeView()
        {
            InitializeComponent();
            BindingContext = new ShakeViewModel();
        }
    }
}
