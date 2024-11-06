using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SensorV3.ViewModels
{
    public class CurrentLocationViewModel : INotifyPropertyChanged
    {
        private string _currentLocation;
        public string CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetLocationCommand { get; }

        public CurrentLocationViewModel()
        {
            GetLocationCommand = new Command(async () => await GetCurrentLocationAndPlacemarkAsync());
            CurrentLocation = "Aquí se mostrará la información de la ubicación actual.";
        }

        private async Task GetCurrentLocationAndPlacemarkAsync()
        {
            try
            {
                // Solicita la ubicación actual del dispositivo
                Location location = await Geolocation.Default.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    CurrentLocation = $"Latitud: {location.Latitude}, Longitud: {location.Longitude}\n";

                    // Usa la latitud y longitud obtenidas para la geocodificación inversa
                    IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    Placemark placemark = placemarks?.FirstOrDefault();

                    if (placemark != null)
                    {
                        CurrentLocation +=
                            $"AdminArea:       {placemark.AdminArea}\n" +
                            $"CountryCode:     {placemark.CountryCode}\n" +
                            $"CountryName:     {placemark.CountryName}\n" +
                            $"FeatureName:     {placemark.FeatureName}\n" +
                            $"Locality:        {placemark.Locality}\n" +
                            $"PostalCode:      {placemark.PostalCode}\n" +
                            $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                            $"SubLocality:     {placemark.SubLocality}\n" +
                            $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                            $"Thoroughfare:    {placemark.Thoroughfare}\n";
                    }
                    else
                    {
                        CurrentLocation += "No se pudo obtener más detalles de la ubicación.";
                    }
                }
                else
                {
                    CurrentLocation = "No se pudo obtener la ubicación.";
                }
            }
            catch (FeatureNotSupportedException)
            {
                CurrentLocation = "La funcionalidad de GPS no está soportada en este dispositivo.";
            }
            catch (FeatureNotEnabledException)
            {
                CurrentLocation = "El GPS está deshabilitado en este dispositivo.";
            }
            catch (PermissionException)
            {
                CurrentLocation = "No se concedieron permisos para acceder a la ubicación.";
            }
            catch (Exception ex)
            {
                CurrentLocation = $"Error al obtener la ubicación: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
