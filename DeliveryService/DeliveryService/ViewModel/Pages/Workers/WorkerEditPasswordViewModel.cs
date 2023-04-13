using DeliveryService.DTO;
using DeliveryService.Services;
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
    public class WorkerEditPasswordViewModel
    {
        #region Private Fields
        private WorkerDTO _worker;

        private IEncryptionService _service;

        private Window _window;

        private RelayCommand? _saveCommand;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _cancelWindowCommand;
        #endregion

        #region Properties
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((obj) =>
                {
                    if ((obj as PasswordBox).Password != null)
                    {
                        _worker.Password = _service.EncryptPassword((obj as PasswordBox).Password);
                        _window.Close();
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
    }
}
