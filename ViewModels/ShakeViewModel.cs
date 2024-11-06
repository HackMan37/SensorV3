using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SensorV3.ViewModels
{
    public class ShakeViewModel : INotifyPropertyChanged
    {
        private string _shakeStatus;
        private string _shakeTextColor;

        public string ShakeStatus
        {
            get => _shakeStatus;
            set
            {
                _shakeStatus = value;
                OnPropertyChanged();
            }
        }

        public string ShakeTextColor
        {
            get => _shakeTextColor;
            set
            {
                _shakeTextColor = value;
                OnPropertyChanged();
            }
        }

        public ShakeViewModel()
        {
            ShakeStatus = "Agita el dispositivo";
            ShakeTextColor = "White";  // Inicialmente blanco
            InitializeShakeDetection();
        }

        private void InitializeShakeDetection()
        {
            if (Accelerometer.Default.IsSupported)
            {
                Accelerometer.Default.ShakeDetected += OnShakeDetected;
                Accelerometer.Default.Start(SensorSpeed.Game);
            }
        }

        private async void OnShakeDetected(object sender, EventArgs e)
        {
            ShakeStatus = "Agitación detectada";
            ShakeTextColor = "Red";

            // Espera 3 segundos antes de restaurar el mensaje
            await Task.Delay(3000);
            ShakeStatus = "Agita el dispositivo";
            ShakeTextColor = "White";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
