using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    /// <summary>
    /// ViewModel для страницы "Пользователи".
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        #region Private Fields
        private IAuthenticationService _authenticationService;

        private UserPages? _currentPage  = UserPages.UserGenerlaInfo;

        private RelayCommand? _changePageCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Текущая страница в разделе "Пользователи".
        /// </summary>
        public UserPages? CurrentPage 
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения страницы в разделе "Пользователи".
        /// </summary>
        public RelayCommand ChangePageCommand { 
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((UserPages)obj))
                    {
                        CurrentPage = (UserPages)obj;
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
        /// Конструктор класса <see cref="UserViewModel"/>.
        /// </summary>
        public UserViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
