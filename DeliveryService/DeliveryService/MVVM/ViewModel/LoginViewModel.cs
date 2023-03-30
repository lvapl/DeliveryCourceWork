using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.View;
using DeliveryService.Services;
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

namespace DeliveryService.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields

        private string _login;
        private RelayCommand _loginCommand;
        private RelayCommand _showPasswordCommand;

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
                return _loginCommand ?? (_loginCommand = new RelayCommand((object? obj) =>
                {
                    var isValidWorker = _authenticationService.AuthenticateWorker(new System.Net.NetworkCredential(_login, (obj as PasswordBox).Password));
                    if (isValidWorker)
                    {
                        ShowMainWindow();
                    }
                }));
            }
        }
        public RelayCommand ShowPasswordCommand 
        { 
            get
            {
                return _showPasswordCommand ?? (_showPasswordCommand = new RelayCommand(obj => 
                {

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

        public void ShowMainWindow()
        {
            _mainWindow.Show();
            _loginWindow.Close();
        }
    }
}
