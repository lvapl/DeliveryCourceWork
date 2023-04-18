using CredentialChecker;
using CredentialChecker.Enums;
using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryService.ViewModel.Pages.Workers
{
    public class WorkerEditPasswordViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerDTO _worker;

        private IEncryptionService _service;

        private Window _window;

        private RelayCommand? _saveCommand;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _cancelWindowCommand;

        private string? _password;

        private int _progressPassword;
        #endregion

        #region Properties
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                ShowValidationPassword();
                OnPropertyChanged();
            }
        }

        public int ProgressPassword
        {
            get => _progressPassword;
            set
            {
                _progressPassword = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((obj) =>
                {
                    if ((int)PasswordChecker.Check(_password) > 1 && _password != null)
                    {
                        _worker.Password = _service.EncryptPassword(_password);
                        _window.Close();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Пароль не введён или слишком простой.");
                        window.ShowDialog();
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
        #endregion

        public WorkerEditPasswordViewModel(Window window, WorkerDTO worker)
        {
            _worker = worker;
            _window = window;
            _service = App.ServiceProvider.GetRequiredService<IEncryptionService>();
        }

        public void ShowValidationPassword()
        {
            PasswordDifficulty passwordDifficulty = PasswordChecker.Check(_password);

            ProgressPassword = (int)passwordDifficulty * 25;
        }
    }
}
