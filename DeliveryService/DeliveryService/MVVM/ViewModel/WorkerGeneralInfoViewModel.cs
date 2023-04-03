using DeliveryService.MVVM.Model.DTO;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.MVVM.ViewModel
{
    public class WorkerGeneralInfoViewModel : ViewModelBase
    {
        private IWorkerGeneralInfoService _service;

        public List<WorkerGeneralInfoDTO>? Workers { get; set; }

        public WorkerGeneralInfoViewModel()
        {
            _service = App._serviceProvider.GetRequiredService<IWorkerGeneralInfoService>();
            Workers = (List<WorkerGeneralInfoDTO>?)_service.GetAll();
        }
    }
}
