using DeliveryService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.ViewModel.Pages
{
    public class WorkerViewModel : ViewModelBase
    {
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
                return _changePageCommand ?? (_changePageCommand = new RelayCommand((obj) =>
                {
                    CurrentPage = (WorkerPages?)obj;

                }));
            }
        }
    }
}
