﻿using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages
{
    public class StorageViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private StoragePages? _currentPage  = StoragePages.StorageGeneralInfo;

        private RelayCommand? _changePageCommand;



        public StoragePages? CurrentPage 
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

        public StorageViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
