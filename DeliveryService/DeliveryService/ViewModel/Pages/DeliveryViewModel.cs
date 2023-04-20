﻿using DeliveryService.Enums;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.ViewModel.Pages
{
    public class DeliveryViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private DeliveryPages? _currentPage  = DeliveryPages.DeliveryGeneralInfo;

        private RelayCommand? _changePageCommand;



        public DeliveryPages? CurrentPage 
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
                    if (obj != null && _authenticationService.HasAccessToSubSection((DeliveryPages)obj))
                    {
                        CurrentPage = (DeliveryPages)obj;
                    }
                    else
                    {
                        CurrentPage = null;
                    }
                }));
            } 
        }

        public DeliveryViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
