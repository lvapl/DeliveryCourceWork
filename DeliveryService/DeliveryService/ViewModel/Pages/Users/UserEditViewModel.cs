using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Users
{
    public class UserEditViewModel : ViewModelBase
    {
        #region Private Fields
        private UserDTO _user;

        private IUserDTOService _userService;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelWindowCommand;

        private RelayCommand? _editAddressCommand;

        private RelayCommand? _editPassportAddressCommand;
        #endregion


        #region Properties
        public UserDTO User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
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

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((obj) =>
                {
                    if (IsFillRequiredFields())
                    {
                        if (_user.Id != 0)
                        {
                            _userService.Edit(_user);
                            _window.Close();
                        }
                        else
                        {
                            _userService.Add(_user);
                            _window.Close();
                        }
                    }
                    else
                    {
                        throw new Exception("Обязательные к поля не заполнены!");
                    }
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

        public RelayCommand EditAddressCommand
        {
            get
            {
                return _editAddressCommand ?? (_editAddressCommand = new RelayCommand((obj) =>
                {
                    if (User.Address == null)
                    {
                        User.Address = new AddressDTO();
                    }

                    Window window = new AddressEdit(User.Address);
                    window.Show();
                }));
            }
        }

        public RelayCommand EditPassportAddressCommand
        {
            get
            {
                return _editPassportAddressCommand ?? (_editPassportAddressCommand = new RelayCommand((obj) =>
                {
                    if (User.PassportAddress == null)
                    {
                        User.PassportAddress = new AddressDTO();
                    }

                    Window window = new AddressEdit(User.PassportAddress);
                    window.Show();
                }));
            }
        }
        #endregion

        public UserEditViewModel(Window window, int? userId)
        {
            _window = window;

            _userService = App.ServiceProvider.GetRequiredService<IUserDTOService>();

            if (userId == null)
            {
                _user = new UserDTO();
            }
            else
            {
                _user = _userService.GetById((int)userId);
            }
        }


        private bool IsFillRequiredFields()
        {
            return !string.IsNullOrWhiteSpace(User.FirstName)
                && !string.IsNullOrWhiteSpace(User.LastName)
                && !string.IsNullOrWhiteSpace(User.TelephoneNumber)
                && User.PassportSeries != 0
                && User.PassportNumber != 0;
        }
    }
}
