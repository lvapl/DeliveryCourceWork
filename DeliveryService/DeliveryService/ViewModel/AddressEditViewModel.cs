using System.Windows;
using DeliveryService.DTO;

namespace DeliveryService.ViewModel
{
    /// <summary>
    /// Модель представления для редактирования адреса.
    /// </summary>
    public class AddressEditViewModel : ViewModelBase
    {
        #region Private Fields
        private AddressDTO _addressOriginal;
        private AddressDTO _address;

        private Window _window;

        private RelayCommand? _saveCommand;
        private RelayCommand? _closeWindowCommand;
        private RelayCommand? _minimizeWindowCommand;
        private RelayCommand? _cancelWindowCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Команда сохранения адреса.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand((obj) =>
                {
                    _addressOriginal.Country = _address.Country;
                    _addressOriginal.CountryId = _address.CountryId;
                    _addressOriginal.City = _address.City;
                    _addressOriginal.CityId = _address.CityId;
                    _addressOriginal.Street = _address.Street;
                    _addressOriginal.StreetId = _address.StreetId;
                    _addressOriginal.House = _address.House;
                    _addressOriginal.HouseId = _address.HouseId;
                    _addressOriginal.Postcode = _address.Postcode;

                    _window.Close();
                });
            }
        }

        /// <summary>
        /// Команда закрытия окна.
        /// </summary>
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }

        /// <summary>
        /// Команда минимизации окна.
        /// </summary>
        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                });
            }
        }

        /// <summary>
        /// Команда отмены изменений.
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }

        /// <summary>
        /// Адрес для редактирования.
        /// </summary>
        public AddressDTO Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="AddressEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно, которое редактирует адрес.</param>
        /// <param name="address">Адрес для редактирования.</param>
        public AddressEditViewModel(Window window, AddressDTO address)
        {
            
            _addressOriginal = address;
            _window = window;
            _address = new AddressDTO()
            {
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                House = address.House,
                Postcode = address.Postcode
            };
            
        }
    }
}
