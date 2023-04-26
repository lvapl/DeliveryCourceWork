using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    /// <summary>
    /// ViewModel для страницы "Сотрудники".
    /// </summary>
    public class WorkerViewModel : ViewModelBase
    {
        #region Private Fields
        private IAuthenticationService _authenticationService;

        private WorkerPages? _currentPage = WorkerPages.WorkerGeneralInfo;

        private RelayCommand? _changePageCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Текущая страница в разделе "Пользователи".
        /// </summary>
        public WorkerPages? CurrentPage
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
        public RelayCommand ChangePageCommand
        {
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((WorkerPages)obj))
                    {
                        CurrentPage = (WorkerPages)obj;
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
        public WorkerViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
