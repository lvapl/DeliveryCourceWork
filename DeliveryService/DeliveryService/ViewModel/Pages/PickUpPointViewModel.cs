using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    /// <summary>
    /// ViewModel для страницы "Пункты выдачи".
    /// </summary>
    public class PickUpPointViewModel : ViewModelBase
    {
        #region Private Field
        private IAuthenticationService _authenticationService;

        private PickUpPointPages? _currentPage  = PickUpPointPages.PickUpPointGeneralInfo;

        private RelayCommand? _changePageCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Текущая страница в разделе "Пункты выдачи".
        /// </summary>
        public PickUpPointPages? CurrentPage 
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения текущей страницы в разделе "Пункты выдачи".
        /// </summary>
        public RelayCommand ChangePageCommand { 
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((PickUpPointPages)obj))
                    {
                        CurrentPage = (PickUpPointPages)obj;
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
        /// Конструктор класса <see cref="PickUpPointViewModel"/>.
        /// </summary>
        public PickUpPointViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
