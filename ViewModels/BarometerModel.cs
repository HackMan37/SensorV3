using System.Windows.Input;
using SensorV3.Models;
using System.ComponentModel;

namespace SensorV3.ViewModels
{
    public class BarometerViewModel : INotifyPropertyChanged
    {
        private BarometerModel _barometerModel;
        private string _pressureText;

        public BarometerViewModel()
        {
            _barometerModel = new BarometerModel();
            CargarPresionCommand = new Command(async () => await CargarPresionAsync());
            PressureText = "Aquí se mostrará la información del barómetro";
        }

        public string PressureText
        {
            get => _pressureText;
            set
            {
                if (_pressureText != value)
                {
                    _pressureText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CargarPresionCommand { get; }

        private async Task CargarPresionAsync()
        {
            if (Barometer.Default.IsSupported)
            {
                try
                {
                    // Suscribirse temporalmente al evento de cambio de lectura
                    Barometer.Default.ReadingChanged += OnBarometerReadingChanged;

                    // Iniciar el barómetro
                    Barometer.Default.Start(SensorSpeed.UI);

                    // Esperar brevemente para obtener la lectura
                    await Task.Delay(500); // Espera 500 milisegundos para asegurar que la lectura sea capturada

                    // Detener el barómetro después de obtener la lectura
                    Barometer.Default.Stop();
                }
                catch (Exception ex)
                {
                    PressureText = $"Error: {ex.Message}";
                }
            }
            else
            {
                PressureText = "El barómetro no es compatible en este dispositivo.";
            }
        }

        private void OnBarometerReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            // Mostrar la lectura del barómetro
            double pressure = Math.Round(e.Reading.PressureInHectopascals, 2);
            _barometerModel.Pressure = pressure;
            PressureText = $"Presión del aire:\n {_barometerModel.Pressure} hPa";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
