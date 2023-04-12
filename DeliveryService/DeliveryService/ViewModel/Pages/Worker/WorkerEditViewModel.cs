using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Worker
{
    public class WorkerEditViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerDTO _worker;

        private ObservableCollection<AddressDTO> _addresses;

        private IWorkerDTOService _service;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelWindowCommand;
        #endregion

        #region Properties
        public WorkerDTO Worker
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
                    _service.Edit(_worker);
                    _window.Close();
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

        public WorkerEditViewModel(Window window, int? workerId)
        {
            _window = window;

            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            if (workerId == null)
            {
                _worker = new WorkerDTO();
            }
            else
            {
                _worker = _service.GetById((int)workerId);
            }
        }
    }
}
