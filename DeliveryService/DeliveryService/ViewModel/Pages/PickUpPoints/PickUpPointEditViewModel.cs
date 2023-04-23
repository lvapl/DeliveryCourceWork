using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.PickUpPoints
{
    public class PickUpPointEditViewModel : ViewModelBase
    {
        #region Private Fields
        private PickUpPointDTO _pickUpPoint;

        private IPickUpPointDTOService _pickUpPointService;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelCommand;
        #endregion


        #region Properties
        public PickUpPointDTO PickUpPoint
        {
            get => _pickUpPoint;
            set
            {
                _pickUpPoint = value;
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
                    if (_pickUpPoint.Id != 0)
                    {
                        _pickUpPointService.Edit(_pickUpPoint);
                        _window.Close();
                    }
                    else
                    {
                        _pickUpPointService.Add(_pickUpPoint);
                        _window.Close();
                    }
                });
            }
        }

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

        public PickUpPointEditViewModel(Window window, int? pointId)
        {
            _window = window;

            _pickUpPointService = App.ServiceProvider.GetRequiredService<IPickUpPointDTOService>();

            _pickUpPoint = pointId == null ? new PickUpPointDTO() : _pickUpPointService.GetById((int)pointId);

            _pickUpPoint.Address ??= new AddressDTO();
        }
    }
}
