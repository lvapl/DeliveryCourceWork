using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    public class WorkerViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private WorkerPages? _currentPage = WorkerPages.WorkerGeneralInfo;

        private RelayCommand? _changePageCommand;

        

        public WorkerPages? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

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

        public WorkerViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
