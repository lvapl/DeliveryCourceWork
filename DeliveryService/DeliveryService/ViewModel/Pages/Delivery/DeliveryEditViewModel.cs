using System.Collections.ObjectModel;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Delivery
{
    /// <summary>
    /// ViewModel для редактирования/добавления <see cref="Model.Delivery"/>.
    /// </summary>
    public class DeliveryEditViewModel : ViewModelBase
    {
        #region Private Fields
        private DeliveryDTO _delivery;

        private IDeliveryDTOService _deliveryService;
        private IUserRepository _userRepository;
        private IPickUpPointRepository _pointRepository;
        private DsContext _context;

        private Window _window;

        private RelayCommand? _closeWindowCommand;
        private RelayCommand? _minimizeWindowCommand;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Информация для редактирования, представленная в виде <see cref="DeliveryDTO"/>.
        /// </summary>
        public DeliveryDTO Delivery
        {
            get => _delivery;
            set
            {
                _delivery = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список пользователей <see cref="User"/>.
        /// </summary>
        public ObservableCollection<User> Users => new ObservableCollection<User>(_userRepository.GetAll());

        /// <summary>
        /// Выбранный пользователь-отправитель <see cref="Model.Delivery.Sender"/>.
        /// </summary>
        public User? Sender 
        {
            get => _delivery.SenderId == null ? null : _userRepository.GetById((int)_delivery.SenderId);
            set
            {
                _delivery.SenderId = value?.Id;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранный пользователь-получатель <see cref="Model.Delivery.Recipient"/>.
        /// </summary>
        public User? Recipient
        {
            get => _delivery.RecipientId == null ? null : _userRepository.GetById((int)_delivery.RecipientId);
            set
            {
                _delivery.RecipientId = value?.Id;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список пунктов выдачи <see cref="PickUpPoint"/>.
        /// </summary>
        public ObservableCollection<PickUpPoint> PickUpPoints => new ObservableCollection<PickUpPoint>(_pointRepository.GetAll());

        /// <summary>
        /// Выбранный пункт получения <see cref="Model.Delivery.PickPoint"/>.
        /// </summary>
        public PickUpPoint? PickPoint
        {
            get => _delivery.PickPointId == null ? null : _pointRepository.GetById((int)_delivery.PickPointId);
            set
            {
                _delivery.PickPointId = value?.Id;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранный пункт приёма <see cref="Model.Delivery.UpPoint"/>.
        /// </summary>
        public PickUpPoint? UpPoint
        {
            get => _delivery.UpPointId == null ? null : _pointRepository.GetById((int)_delivery.UpPointId);
            set
            {
                _delivery.UpPointId = value?.Id;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список тарифов <see cref="Model.Tariff"/>.
        /// </summary>
        public ObservableCollection<Tariff> Tariffs => new ObservableCollection<Tariff>(_context.Tariffs);

        /// <summary>
        /// Выбранный тариф <see cref="Model.Delivery.Tariff"/>.
        /// </summary>
        public Tariff? Tariff
        {
            get => _delivery.TariffId == null ? null : _context.Tariffs.Find((int)_delivery.TariffId);
            set
            {
                _delivery.TariffId = value?.Id;
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
                    if (_delivery.Id != 0)
                    {
                        _deliveryService.Edit(_delivery);
                        _window.Close();
                    }
                    else
                    {
                        _deliveryService.Add(_delivery);
                        _window.Close();
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
                return _cancelCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="DeliveryEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно для редактирования данных.</param>
        /// <param name="deliveryId">Id доставки для редактирования, если null, то создается новый объект.</param>
        public DeliveryEditViewModel(Window window, int? deliveryId)
        {
            _window = window;

            _deliveryService = App.ServiceProvider.GetRequiredService<IDeliveryDTOService>();
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
            _pointRepository = App.ServiceProvider.GetRequiredService<IPickUpPointRepository>();
            _context = App.ServiceProvider.GetRequiredService<DsContext>();

            _delivery = deliveryId == null ? new DeliveryDTO() : _deliveryService.GetById((int)deliveryId);
        }
    }
}
