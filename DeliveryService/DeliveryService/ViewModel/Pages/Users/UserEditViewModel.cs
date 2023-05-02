using System;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Users
{
    /// <summary>
    /// ViewModel для редактирования/добавления <see cref="Model.User"/>.
    /// </summary>
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
        /// <summary>
        /// Информация для редактирования, представленная в виде <see cref="UserDTO"/>.
        /// </summary>
        public UserDTO User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для закрытия окна.
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
        /// Команда для сворачивания окна.
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
        /// Команда для сохранения.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand((obj) =>
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
                        throw new Exception("Обязательные поля не заполнены!");
                    }
                });
            }
        }

        /// <summary>
        /// Команда для отмены изменений и закрытия окна.
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
        /// Команда для открытия окна редактирования адреса.
        /// </summary>
        public RelayCommand EditAddressCommand
        {
            get
            {
                return _editAddressCommand ??= new RelayCommand((obj) =>
                {
                    User.Address ??= new AddressDTO();

                    Window window = new AddressEdit(User.Address);
                    window.Show();
                });
            }
        }

        /// <summary>
        /// Команда для открытия окна редактирования адреса по паспорту.
        /// </summary>
        public RelayCommand EditPassportAddressCommand
        {
            get
            {
                return _editPassportAddressCommand ??= new RelayCommand((obj) =>
                {
                    User.PassportAddress ??= new AddressDTO();

                    Window window = new AddressEdit(User.PassportAddress);
                    window.Show();
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="DeliveryEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно для редактирования данных.</param>
        /// <param name="userId">Id пользователя для редактирования, если null, то создается новый объект.</param>
        public UserEditViewModel(Window window, int? userId)
        {
            _window = window;

            _userService = App.ServiceProvider.GetRequiredService<IUserDTOService>();

            _user = userId == null ? new UserDTO() : _userService.GetById((int)userId);
        }

        /// <summary>
        /// Метод проверки заполненности обязательных полей.
        /// </summary>
        /// <returns>True - поля заполнены, false - не все поля заполнены.</returns>
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
