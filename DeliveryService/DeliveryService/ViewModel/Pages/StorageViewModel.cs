using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    /// <summary>
    /// ViewModel для страницы "Склад".
    /// </summary>
    public class StorageViewModel : ViewModelBase
    {
        #region Private Fields
        private IAuthenticationService _authenticationService;

        private StoragePages? _currentPage  = StoragePages.StorageGeneralInfo;

        private RelayCommand? _changePageCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Текущая страница в разделе "Склад".
        /// </summary>
        public StoragePages? CurrentPage 
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда смены страницы в разделе "Склад".
        /// </summary>
        public RelayCommand ChangePageCommand { 
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((StoragePages)obj))
                    {
                        CurrentPage = (StoragePages)obj;
                    }
                    else
                    {
                        CurrentPage = null;
                    }
                });
            } 
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="StorageViewModel"/>.
        /// </summary>
        public StorageViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
