using System.Net;
using System.Windows;
using System.Windows.Controls;
using DeliveryService.Model;
using DeliveryService.Services;
using DeliveryService.View;

namespace DeliveryService.ViewModel
{
    /// <summary>
    /// Модель представления для окна авторизации пользователя
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region Private Fields

        private string _login;
        private RelayCommand _loginCommand;
        private RelayCommand _closeWindowCommand;
        private RelayCommand _minimizeWindowCommand;
        private bool _errorMessageVisibility;

        private LoginWindow _loginWindow;
        private MainWindow _mainWindow;

        private IAuthenticationService _authenticationService;
        #endregion

        #region Properties
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда авторизации пользователя
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                ErrorMessageVisibility = false;
                return _loginCommand ??= new RelayCommand((obj) =>
                {
                    Worker? worker = _authenticationService.AuthenticateWorker(new NetworkCredential(_login, (obj as PasswordBox).Password));
                    if (worker != null)
                    {
                        (_mainWindow.DataContext as MainWindowViewModel).CurrentWorker = worker;
                        ShowMainWindow();
                    }
                    else
                    {
                        ErrorMessageVisibility = true;
                    }
                });
            }
        }

        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??= new RelayCommand((obj) =>
                {
                    App.Current.Shutdown();
                });
            }
        }

        /// <summary>
        /// Команда сворачивания окна
        /// </summary>
        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _loginWindow.WindowState = WindowState.Minimized;
                });
            }
        }

        /// <summary>
        /// Флаг видимости сообщения об ошибке авторизации
        /// </summary>
        public bool ErrorMessageVisibility
        {
            get => _errorMessageVisibility;
            set
            {
                _errorMessageVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="LoginViewModel"/>.
        /// </summary>
        /// <param name="authenticationService">Сервис аутентификации</param>
        /// <param name="loginWindow">Окно авторизации</param>
        /// <param name="mainWindow">Главное окно</param>
        public LoginViewModel(IAuthenticationService authenticationService, LoginWindow loginWindow, MainWindow mainWindow)
        {
            _authenticationService = authenticationService;
            _loginWindow = loginWindow;
            _mainWindow = mainWindow;
        }

        #region Methods
        /// <summary>
        /// Отображение главного окна при успешной авторизации
        /// </summary>
        public void ShowMainWindow()
        {
            _mainWindow.Show();
            _loginWindow.Close();

            ErrorMessageVisibility = false;
        }
        #endregion
    }
}
