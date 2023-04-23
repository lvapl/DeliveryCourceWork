using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Storages
{
    public class StorageEditViewModel : ViewModelBase
    {
        #region Private Fields
        private StorageDTO _storage;

        private IStorageDTOService _storageService;

        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private RelayCommand? _saveCommand;

        private RelayCommand? _cancelCommand;

        private RelayCommand? _editAddressCommand;
        #endregion

        #region Properties
        public StorageDTO Storage
        {
            get => _storage;
            set
            {
                _storage = value;
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

        public RelayCommand EditAddressCommand
        {
            get
            {
                return _editAddressCommand ??= new RelayCommand((obj) =>
                {
                    Storage.Address ??= new AddressDTO();

                    Window window = new AddressEdit(Storage.Address);
                    window.ShowDialog();
                    OnPropertyChanged(nameof(Storage));
                });
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand((obj) =>
                {
                    if (_storage.Id != 0)
                    {
                        _storageService.Edit(_storage);
                    }
                    else
                    {
                        _storageService.Add(_storage);
                    }
                    _window.Close();
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

        public StorageEditViewModel(Window window, int? storageId)
        {
            _window = window;

            _storageService = App.ServiceProvider.GetRequiredService<IStorageDTOService>();

            _storage = storageId == null ? new StorageDTO() : _storageService.GetById((int)storageId);
        }
    }
}
