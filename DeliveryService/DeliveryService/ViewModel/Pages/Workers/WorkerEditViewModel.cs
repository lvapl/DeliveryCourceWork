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
    /// <summary>
    /// ViewModel для редактирования/добавления <see cref="Model.Worker"/>.
    /// </summary>
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
        /// <summary>
        /// Информация для редактирования, представленная в виде <see cref="WorkerDTO"/>.
        /// </summary>
        public WorkerDTO Worker
        {
            get => _worker;
            set
            {
                _worker = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для закрытия окна.
        /// </summary>
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

        /// <summary>
        /// Команда для сворачивания окна.
        /// </summary>
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

        /// <summary>
        /// Команда для сохранения.
        /// </summary>
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
                        throw new Exception("Обязательные поля не заполнены!");
                    }
                });
            }
        }

        /// <summary>
        /// Команда для отмены изменений и закрытия окна.
        /// </summary>
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

        /// <summary>
        /// Команда для открытия окна редактирования пароля.
        /// </summary>
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

        /// <summary>
        /// Команда для открытия окна редактирования адреса.
        /// </summary>
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

        /// <summary>
        /// Команда для открытия окна редактирования адреса по паспорту.
        /// </summary>
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

        /// <summary>
        /// Список должностей <see cref="Model.Position"/>.
        /// </summary>
        public ObservableCollection<Position> Positions => new ObservableCollection<Position>(_positionRepository.GetAll());

        /// <summary>
        /// Выбранная должность <see cref="Model.Worker.Position"/>.
        /// </summary>
        public Position? Position
        {
            get => _worker.PositionId == 0 ? null : _positionRepository.GetById(_worker.PositionId);
            set
            {
                _worker.PositionId = value?.Id ?? _worker.PositionId;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для открытия окна выбора изображения
        /// </summary>
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

        /// <summary>
        /// Конструктор класса <see cref="WorkerEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно для редактирования данных.</param>
        /// <param name="workerId">Id сотрудника для редактирования, если null, то создается новый объект.</param>
        public WorkerEditViewModel(Window window, int? workerId)
        {
            _window = window;

            _workerService = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _positionRepository = App.ServiceProvider.GetRequiredService<IPositionRepository>();

            _worker = workerId == null ? new WorkerDTO() : _workerService.GetById((int)workerId);
        }

        /// <summary>
        /// Метод проверки заполненности обязательных полей.
        /// </summary>
        /// <returns>True - поля заполнены, false - не все поля заполнены.</returns>
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
