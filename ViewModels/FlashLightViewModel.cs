using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SensorV3.ViewModels
{
    public class FlashLightViewModel : INotifyPropertyChanged
    {
        private string _flashLightStatus;
        private string _buttonText;
        private bool _isFlashlightOn;

        public string FlashLightStatus
        {
            get => _flashLightStatus;
            set
            {
                _flashLightStatus = value;
                OnPropertyChanged();
            }
        }

        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleFlashLightCommand { get; }

        public FlashLightViewModel()
        {
            ToggleFlashLightCommand = new Command(ToggleFlashLight);
            FlashLightStatus = "Aquí se mostrará la información de la linterna";
            ButtonText = "Encender Linterna";
            _isFlashlightOn = false;
        }

        private async void ToggleFlashLight()
        {
            if (_isFlashlightOn)
            {
                await Flashlight.Default.TurnOffAsync();
                _isFlashlightOn = false;
                ButtonText = "Encender Linterna";
                FlashLightStatus = "Haz apagado la linterna";
            }
            else
            {
                await Flashlight.Default.TurnOnAsync();
                _isFlashlightOn = true;
                ButtonText = "Apagar Linterna";
                FlashLightStatus = "Haz encendido la linterna";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
