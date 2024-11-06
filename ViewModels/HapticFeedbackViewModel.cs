using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SensorV3.ViewModels
{
    public class HapticFeedbackViewModel : INotifyPropertyChanged
    {
        private string _feedbackStatus;
        private string _buttonText;

        public string FeedbackStatus
        {
            get => _feedbackStatus;
            set
            {
                _feedbackStatus = value;
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

        public ICommand PerformHapticFeedbackCommand { get; }

        public HapticFeedbackViewModel()
        {
            PerformHapticFeedbackCommand = new Command(PerformHapticFeedback);
            FeedbackStatus = "Aquí se mostrará la información de la vibración por toque o HapticFeedback";
            ButtonText = "Obtener vibración";
        }

        private void PerformHapticFeedback()
        {
            if (HapticFeedback.Default.IsSupported)
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
                FeedbackStatus = "Si no hubo una vibración pequeña, verifica las opciones del dispositivo";
            }
            else
            {
                FeedbackStatus = "La retroalimentación háptica no es compatible en este dispositivo.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
