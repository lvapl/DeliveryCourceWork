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
    public class UserViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private UserPages? _currentPage  = UserPages.UserGenerlaInfo;

        private RelayCommand? _changePageCommand;



        public UserPages? CurrentPage 
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
                    if (obj != null && _authenticationService.HasAccessToSubSection((UserPages)obj))
                    {
                        CurrentPage = (UserPages)obj;
                    }
                    else
                    {
                        CurrentPage = null;
                    }
                }));
            } 
        }

        public UserViewModel()
        {
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
