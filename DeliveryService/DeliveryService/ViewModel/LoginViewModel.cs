using System.Net;
using System.Windows;
using System.Windows.Controls;
using DeliveryService.Model;
using DeliveryService.Services;
using DeliveryService.View;

namespace DeliveryService.ViewModel
{
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

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

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

        public LoginViewModel(IAuthenticationService authenticationService, LoginWindow loginWindow, MainWindow mainWindow)
        {
            _authenticationService = authenticationService;
            _loginWindow = loginWindow;
            _mainWindow = mainWindow;
        }

        #region Methods
        public void ShowMainWindow()
        {
            _mainWindow.Show();
            _loginWindow.Close();

            ErrorMessageVisibility = false;
        }
        #endregion
    }
}
