using System.ComponentModel;
using System.Runtime.CompilerServices;

// Cambiar segun nombre del proyecto
namespace SensorV3.ViewModels;

public class BaseViewModel: INotifyPropertyChanged
{

    #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }



    #endregion

}