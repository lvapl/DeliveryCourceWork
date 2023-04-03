using DeliveryService.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public WorkerGeneralInfoPage WorkerGeneralInfoPage { get; set; } = new WorkerGeneralInfoPage();
    }
}
