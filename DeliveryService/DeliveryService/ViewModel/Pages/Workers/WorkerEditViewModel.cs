using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        private IWorkerDTOService _workerService;
        private IAddressDTOService _addressService;
        private IPositionRepository _positionRepository;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelWindowCommand;

        private RelayCommand? _editPasswordCommand;

        private RelayCommand? _editAddressCommand;

        private RelayCommand? _editPassportAddressCommand;

        private RelayCommand? _chooseImageCommand;
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

        public RelayCommand EditAddressCommand
        {
            get
            {
                return _editAddressCommand ?? (_editAddressCommand = new RelayCommand((obj) =>
                {
                    if (Worker.Address == null)
                    {
                        Worker.Address = new AddressDTO();
                    }

                    Window window = new AddressEdit(Worker.Address);
                    window.Show();
                }));
            }
        }

        public RelayCommand EditPassportAddressCommand
        {
            get
            {
                return _editPassportAddressCommand ?? (_editPassportAddressCommand = new RelayCommand((obj) =>
                {
                    if (Worker.PassportAddress == null)
                    {
                        Worker.PassportAddress = new AddressDTO();
                    }

                    Window window = new AddressEdit(Worker.PassportAddress);
                    window.Show();
                }));
            }
        }

        public ObservableCollection<Position>? Positions{ get => new ObservableCollection<Position>(_positionRepository.GetAll()); }

        public Position? Position
        {
            get => _positionRepository.GetById(_worker.PositionId);
            set
            {
                _worker.PositionId = value == null ? _worker.PositionId : value.Id;
            }
        }

        public RelayCommand? ChooseImageCommand
        {
            get
            {
                return _chooseImageCommand ?? (_chooseImageCommand = new RelayCommand((obj) =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files (*.png; *.bmp; *.jpg; *.gif; *.jpeg) | *.png; *.bmp; *.jpg; *.gif; *.jpeg | All files(*.*) | *.*";
                    if (openFileDialog.ShowDialog() ?? false)
                    {
                        Worker.WorkerImage = File.ReadAllBytes(openFileDialog.FileName);
                    }
                    
                }));
            }
        }
        #endregion

        public WorkerEditViewModel(Window window, int? workerId)
        {
            _window = window;

            _workerService = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _addressService = App.ServiceProvider.GetRequiredService<IAddressDTOService>();
            _positionRepository = App.ServiceProvider.GetRequiredService<IPositionRepository>();

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
