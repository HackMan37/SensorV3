using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SensorV3.ViewModels
{
    public class DeviceInformationViewModel : INotifyPropertyChanged
    {
        private string _deviceInformation;
        public string DeviceInformation
        {
            get => _deviceInformation;
            set
            {
                _deviceInformation = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetDeviceInformationCommand { get; }

        public DeviceInformationViewModel()
        {
            GetDeviceInformationCommand = new Command(LoadDeviceInformation);
            DeviceInformation = "Aquí se mostrará la información del dispositivo.";
        }

        private void LoadDeviceInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ancho en píxeles: {DeviceDisplay.Current.MainDisplayInfo.Width}");
            sb.AppendLine($"Alto en píxeles: {DeviceDisplay.Current.MainDisplayInfo.Height}");
            sb.AppendLine($"Densidad: {DeviceDisplay.Current.MainDisplayInfo.Density}");
            sb.AppendLine($"Orientación: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
            sb.AppendLine($"Rotación: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
            sb.AppendLine($"Tasa de refresco: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");

            DeviceInformation = sb.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
