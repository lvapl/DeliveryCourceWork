using DeliveryService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.ViewModel.Pages
{
    public class UserViewModel : ViewModelBase
    {
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
                    CurrentPage = (UserPages?)obj;
                }));
            } 
        }
    }
}
