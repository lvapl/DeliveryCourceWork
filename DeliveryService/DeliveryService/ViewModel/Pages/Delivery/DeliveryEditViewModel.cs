using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Delivery
{
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
        public DeliveryDTO Delivery
        {
            get => _delivery;
            set
            {
                _delivery = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User>? Users { get => new ObservableCollection<User>(_userRepository.GetAll()); }

        public User? Sender 
        {
            get => _delivery.SenderId == null ? null : _userRepository.GetById((int)_delivery.SenderId);
            set
            {
                _delivery.SenderId = value == null ? null : value.Id;
                OnPropertyChanged();
            }
        }

        public User? Recipient
        {
            get => _delivery.RecipientId == null ? null : _userRepository.GetById((int)_delivery.RecipientId);
            set
            {
                _delivery.RecipientId = value == null ? null : value.Id;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PickUpPoint>? PickUpPoints { get => new ObservableCollection<PickUpPoint>(_pointRepository.GetAll()); }

        public PickUpPoint? PickPoint
        {
            get => _delivery.PickPointId == null ? null : _pointRepository.GetById((int)_delivery.PickPointId);
            set
            {
                _delivery.PickPointId = value == null ? null : value.Id;
                OnPropertyChanged();
            }
        }
        
        public PickUpPoint? UpPoint
        {
            get => _delivery.UpPointId == null ? null : _pointRepository.GetById((int)_delivery.UpPointId);
            set
            {
                _delivery.UpPointId = value == null ? null : value.Id;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tariff>? Tariffs { get => new ObservableCollection<Tariff>(_context.Tariffs); }

        public Tariff? Tariff
        {
            get => _delivery.TariffId == null ? null : _context.Tariffs.Find((int)_delivery.TariffId);
            set
            {
                _delivery.TariffId = value == null ? null : value.Id;
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
                }));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand((obj) =>
                {
                    _window.Close();
                }));
            }
        }
        #endregion

        public DeliveryEditViewModel(Window window, int? deliveryId)
        {
            _window = window;

            _deliveryService = App.ServiceProvider.GetRequiredService<IDeliveryDTOService>();
            _userRepository = App.ServiceProvider.GetRequiredService<IUserRepository>();
            _pointRepository = App.ServiceProvider.GetRequiredService<IPickUpPointRepository>();
            _context = App.ServiceProvider.GetRequiredService<DsContext>();

            if (deliveryId == null)
            {
                _delivery = new DeliveryDTO();
            }
            else
            {
                _delivery = _deliveryService.GetById((int)deliveryId);
            }
        }
    }
}
