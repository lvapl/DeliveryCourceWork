using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Storages
{
    /// <summary>
    /// ViewModel для редактирования/добавления <see cref="Model.Storage"/>.
    /// </summary>
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
        /// <summary>
        /// Информация для редактирования, представленная в виде <see cref="StorageDTO"/>.
        /// </summary>
        public StorageDTO Storage
        {
            get => _storage;
            set
            {
                _storage = value;
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
        /// Команда для открытия окна редактирования адреса.
        /// </summary>
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

        /// <summary>
        /// Команда для сохранения.
        /// </summary>
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
        /// Конструктор класса <see cref="StorageEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно для редактирования данных.</param>
        /// <param name="storageId">Id склада для редактирования, если null, то создается новый объект.</param>
        public StorageEditViewModel(Window window, int? storageId)
        {
            _window = window;

            _storageService = App.ServiceProvider.GetRequiredService<IStorageDTOService>();

            _storage = storageId == null ? new StorageDTO() : _storageService.GetById((int)storageId);
        }
    }
}
