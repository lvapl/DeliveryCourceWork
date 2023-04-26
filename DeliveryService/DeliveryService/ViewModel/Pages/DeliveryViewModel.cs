using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    /// <summary>
    /// Модель представления для страницы "Доставки".
    /// </summary>
    public class DeliveryViewModel : ViewModelBase
    {
        #region Private Fields
        private IAuthenticationService _authenticationService;

        private DeliveryPages? _currentPage  = DeliveryPages.DeliveryGeneralInfo;

        private RelayCommand? _changePageCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Текущая страница в разделе "Доставки".
        /// </summary>
        public DeliveryPages? CurrentPage 
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для перехода на другую страницу раздела "Доставки".
        /// </summary>
        public RelayCommand ChangePageCommand { 
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((DeliveryPages)obj))
                    {
                        CurrentPage = (DeliveryPages)obj;
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
        /// Конструктор класса <see cref="DeliveryViewModel"/>.
        /// </summary>
        public DeliveryViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
