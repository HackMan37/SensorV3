using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SensorV3.ViewModels
{
    public class VibrationViewModel : INotifyPropertyChanged
    {
        private string _vibrationStatus;

        public string VibrationStatus
        {
            get => _vibrationStatus;
            set
            {
                _vibrationStatus = value;
                OnPropertyChanged();
            }
        }

        // Propiedad para el comando
        public ICommand VibrateCommand { get; }

        public VibrationViewModel()
        {
            VibrationStatus = "Vibrar";
            // Crear el comando y asignarle el método OnVibrateButtonClicked
            VibrateCommand = new Command(OnVibrateButtonClicked);
        }

        // Método que se ejecutará cuando el comando sea invocado
        private async void OnVibrateButtonClicked()
        {
            // Cancelar cualquier vibración en curso
            Vibration.Default.Cancel();

            VibrationStatus = "Vibrando";

            // Definir la duración de la vibración
            int secondsToVibrate = 1;  // Vibrar por 1 segundo (esto podría variar dependiendo del dispositivo)
            TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

            // Iniciar la vibración
            Vibration.Default.Vibrate(vibrationLength);

            // Esperar 3 segundos antes de cambiar el texto nuevamente
            await Task.Delay(3000);

            VibrationStatus = "Vibrar";  // Restablecer el estado después de que termine la vibración
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
