using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SensorV3.ViewModels
{
    public class BatteryPercentViewModel : INotifyPropertyChanged
    {
        private string _batteryStatus;
        private string _chargeLevel;

        public string BatteryStatus
        {
            get => _batteryStatus;
            set
            {
                _batteryStatus = value;
                OnPropertyChanged();
            }
        }

        public string ChargeLevel
        {
            get => _chargeLevel;
            set
            {
                _chargeLevel = value;
                OnPropertyChanged();
            }
        }

        public ICommand CheckBatteryCommand { get; }

        public BatteryPercentViewModel()
        {
            CheckBatteryCommand = new Command(CheckBatteryLevel);
            BatteryStatus = "Aqui se mostrara el porcentaje de la bateria y el estado";
            ChargeLevel = string.Empty;
        }

        private void CheckBatteryLevel()
        {
            double chargeLevel = Battery.Default.ChargeLevel;
            BatteryState state = Battery.Default.State;

            BatteryStatus = state switch
            {
                BatteryState.Charging => "Battery is currently charging",
                BatteryState.Discharging => "Charger is not connected and the battery is discharging",
                BatteryState.Full => "Battery is full",
                BatteryState.NotCharging => "The battery isn't charging.",
                BatteryState.NotPresent => "Battery is not available.",
                BatteryState.Unknown => "Battery state is unknown",
                _ => "Battery state is unknown"
            };

            ChargeLevel = $"Battery is {chargeLevel * 100}% charged.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
