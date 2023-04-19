using DeliveryService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.ViewModel.Pages
{
    public class StorageViewModel : ViewModelBase
    {
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
                return _changePageCommand ?? (_changePageCommand = new RelayCommand((obj) =>
                {
                    CurrentPage = (StoragePages?)obj;
                }));
            } 
        }
    }
}
