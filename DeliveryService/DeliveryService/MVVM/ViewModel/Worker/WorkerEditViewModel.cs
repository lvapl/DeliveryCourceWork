using DeliveryService.MVVM.Model.DTO;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.MVVM.ViewModel.Worker
{
    public class WorkerEditViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerGeneralInfoDTO _worker;

        private ObservableCollection<AddressDTO> _addresses;

        private IWorkerGeneralInfoService _service;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelWindowCommand;
        #endregion

        #region Properties
        public WorkerGeneralInfoDTO Worker
        {
            get => _worker;
            set
            {
                _worker = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ?? (_closeWindowCommand = new RelayCommand((object? obj) =>
                {
                    _window.Close();
                }));
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ?? (_minimizeWindowCommand = new RelayCommand((object? obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                }));
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((object? obj) =>
                {
                    _service.Edit(_worker);
                }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelWindowCommand ?? (_cancelWindowCommand = new RelayCommand((object? obj) =>
                {
                    _window.Close();
                }));
            }
        }
        #endregion

        public WorkerEditViewModel(Window window, int workerId)
        {
            _window = window;

            _service = App.ServiceProvider.GetRequiredService<IWorkerGeneralInfoService>();
            _worker = _service.GetById(workerId);
        }
    }
}
