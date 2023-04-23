using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

namespace DeliveryService.ViewModel.Pages.Workers
{
    public class WorkerEditViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerDTO _worker;

        private IWorkerDTOService _workerService;
        
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
                return _closeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                });
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand((obj) =>
                {
                    if (IsFillRequiredFields())
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
                    }
                    else
                    {
                        throw new Exception("Обязательные к поля не заполнены!");
                    }
                });
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }

        public RelayCommand EditPasswordCommand
        {
            get
            {
                return _editPasswordCommand ??= new RelayCommand((obj) =>
                {
                    Window window = new WorkerEditPassword(_worker);
                    window.Show();
                });
            }
        }

        public RelayCommand EditAddressCommand
        {
            get
            {
                return _editAddressCommand ??= new RelayCommand((obj) =>
                {
                    Worker.Address ??= new AddressDTO();

                    Window window = new AddressEdit(Worker.Address);
                    window.ShowDialog();
                    OnPropertyChanged(nameof(Worker));
                });
            }
        }

        public RelayCommand EditPassportAddressCommand
        {
            get
            {
                return _editPassportAddressCommand ??= new RelayCommand((obj) =>
                {
                    Worker.PassportAddress ??= new AddressDTO();

                    Window window = new AddressEdit(Worker.PassportAddress);
                    window.ShowDialog();
                    OnPropertyChanged(nameof(Worker));
                });
            }
        }

        public ObservableCollection<Position> Positions => new ObservableCollection<Position>(_positionRepository.GetAll());

        public Position? Position
        {
            get => _worker.PositionId == 0 ? null : _positionRepository.GetById(_worker.PositionId);
            set
            {
                _worker.PositionId = value?.Id ?? _worker.PositionId;
                OnPropertyChanged();
            }
        }

        public RelayCommand ChooseImageCommand
        {
            get
            {
                return _chooseImageCommand ??= new RelayCommand((obj) =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Image Files (*.png; *.bmp; *.jpg; *.gif; *.jpeg) | *.png; *.bmp; *.jpg; *.gif; *.jpeg | All files(*.*) | *.*"
                    };
                    if (openFileDialog.ShowDialog() ?? false)
                    {
                        Worker.WorkerImage = File.ReadAllBytes(openFileDialog.FileName);
                    }
                    
                });
            }
        }
        #endregion

        public WorkerEditViewModel(Window window, int? workerId)
        {
            _window = window;

            _workerService = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _positionRepository = App.ServiceProvider.GetRequiredService<IPositionRepository>();

            _worker = workerId == null ? new WorkerDTO() : _workerService.GetById((int)workerId);
        }


        private bool IsFillRequiredFields()
        {
            return !string.IsNullOrWhiteSpace(Worker.FirstName)
                && !string.IsNullOrWhiteSpace(Worker.LastName)
                && !string.IsNullOrWhiteSpace(Worker.TelephoneNumber)
                && !string.IsNullOrWhiteSpace(Worker.Login)
                && Worker.PositionId != 0
                && !string.IsNullOrWhiteSpace(Worker.Password.ToString())
                && Worker.PassportSeries != 0
                && Worker.PassportNumber != 0;
        }
    }
}
