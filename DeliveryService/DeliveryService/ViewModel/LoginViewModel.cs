using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private DsContext _context;

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
                return _loginCommand ?? (_loginCommand = new RelayCommand((obj) =>
                {
                    Worker? worker = _authenticationService.AuthenticateWorker(new System.Net.NetworkCredential(_login, (obj as PasswordBox).Password));
                    if (worker != null)
                    {
                        (_mainWindow.DataContext as MainWindowViewModel).CurrentWorker = worker;
                        ShowMainWindow();
                    }
                    else
                    {
                        ErrorMessageVisibility = true;
                    }
                }));
            }
        }
        
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ?? (_closeWindowCommand = new RelayCommand((obj) =>
                {
                    App.Current.Shutdown();
                }));
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ?? (_minimizeWindowCommand = new RelayCommand((obj) =>
                {
                    _loginWindow.WindowState = WindowState.Minimized;
                }));
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

        public LoginViewModel(IAuthenticationService authenticationService, DsContext context, LoginWindow loginWindow, MainWindow mainWindow)
        {
            _authenticationService = authenticationService;
            _loginWindow = loginWindow;
            _context = context;
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
