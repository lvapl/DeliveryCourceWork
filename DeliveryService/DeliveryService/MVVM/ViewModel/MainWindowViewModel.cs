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

    }
}
