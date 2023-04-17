using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryService.ViewModel
{
    public class AddressEditViewModel : ViewModelBase
    {
        private AddressDTO _addressOriginal;

        private AddressDTO _address;

        private Window _window;

        private RelayCommand? _saveCommand;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _cancelWindowCommand;



        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((obj) =>
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
                }));
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ?? (_closeWindowCommand = new RelayCommand((obj) =>
                {
                    _window.Close();
                }));
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ?? (_minimizeWindowCommand = new RelayCommand((obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelWindowCommand ?? (_cancelWindowCommand = new RelayCommand((obj) =>
                {
                    _window.Close();
                }));
            }
        }

        public AddressDTO Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

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
