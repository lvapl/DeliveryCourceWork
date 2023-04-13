using DeliveryService.Model;
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

        private MainWindow _mainWindow;
        private LoginWindow _loginWindow;

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
                return _loginCommand ?? (_loginCommand = new RelayCommand((obj) =>
                {
                    var isValidWorker = _authenticationService.AuthenticateWorker(new System.Net.NetworkCredential(_login, (obj as PasswordBox).Password));
                    if (isValidWorker)
                    {
                        ShowMainWindow();
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
        #endregion

        public LoginViewModel(IAuthenticationService authenticationService, MainWindow mainWindow, LoginWindow loginWindow)
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
        }
        #endregion
    }
}
