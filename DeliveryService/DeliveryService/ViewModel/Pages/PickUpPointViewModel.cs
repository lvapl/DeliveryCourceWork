using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.ViewModel.Pages
{
    public class PickUpPointViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private PickUpPointPages? _currentPage  = PickUpPointPages.PickUpPointGeneralInfo;

        private RelayCommand? _changePageCommand;



        public PickUpPointPages? CurrentPage 
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ChangePageCommand { 
            get
            {
                return _changePageCommand ?? (_changePageCommand = new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSubSection((PickUpPointPages)obj))
                    {
                        CurrentPage = (PickUpPointPages)obj;
                    }
                    else
                    {
                        CurrentPage = null;
                    }
                }));
            } 
        }

        public PickUpPointViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
