using DeliveryService.Enums;
using DeliveryService.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeliveryService.MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public AppPages CurrentPage { get; set; } = AppPages.WorkerGeneralInfo;

        private RelayCommand? _changePageCommand;

        public RelayCommand ChangePageCommand
        {
            get
            {
                return _changePageCommand ?? (_changePageCommand = new RelayCommand((object? obj) =>
                {
                    CurrentPage = (AppPages)obj;
                }));
            }
        }
    }
}
