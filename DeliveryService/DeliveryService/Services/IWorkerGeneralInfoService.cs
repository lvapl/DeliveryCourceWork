using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IWorkerGeneralInfoService
    {
        public void Add(WorkerGeneralInfoDTO workerGeneralInfoDTO);

        public void Edit(WorkerGeneralInfoDTO workerGeneralInfoDTO);

        public void Remove(int id);

        public WorkerGeneralInfoDTO GetById(int id);

        public IEnumerable<WorkerGeneralInfoDTO> GetAll();
    }
}
