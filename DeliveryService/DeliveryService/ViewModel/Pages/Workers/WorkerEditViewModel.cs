using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View.Pages.Workers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Workers
{
    public class WorkerEditViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerDTO _worker;

        private ObservableCollection<AddressDTO> _addresses;

        private ObservableCollection<Position> _positions;

        private IWorkerDTOService _workerService;
        private IAddressDTOService _addressService;
        private IPositionRepository _positionRepository;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelWindowCommand;

        private RelayCommand? _editPasswordCommand;
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
                    if(_worker.Id != 0)
                    {
                        _workerService.Edit(_worker);
                        _window.Close();
                    }
                    else
                    {
                        _workerService.Add(_worker);
                        _window.Close();
                    }
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

        public RelayCommand EditPasswordCommand
        {
            get
            {
                return _editPasswordCommand ?? (_editPasswordCommand = new RelayCommand((obj) =>
                {
                    Window window = new WorkerEditPassword(_worker);
                    window.Show();
                }));
            }
        }

        public ObservableCollection<Position> Positions
        {
            get => _positions;
        }
        #endregion

        public WorkerEditViewModel(Window window, int? workerId)
        {
            _window = window;

            _workerService = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _addressService = App.ServiceProvider.GetRequiredService<IAddressDTOService>();
            _positionRepository = App.ServiceProvider.GetRequiredService<IPositionRepository>();

            _addresses = new ObservableCollection<AddressDTO>(_addressService.GetAll());
            _positions = new ObservableCollection<Position>(_positionRepository.GetAll());

            if (workerId == null)
            {
                _worker = new WorkerDTO();
            }
            else
            {
                _worker = _workerService.GetById((int)workerId);
            }
        }

        private bool IsFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(_worker.FirstName)
                || string.IsNullOrWhiteSpace(_worker.LastName)
                || string.IsNullOrWhiteSpace(_worker.Title)
                || string.IsNullOrWhiteSpace(_worker.TelephoneNumber)
                || _worker.Password != null
                || _worker.PassportNumber != 0
                || _worker.PassportSeries != 0;
        }
    }
}
