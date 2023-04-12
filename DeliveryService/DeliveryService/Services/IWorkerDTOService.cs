using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IWorkerDTOService
    {
        public void Add(WorkerDTO workerGeneralInfoDTO);

        public void Edit(WorkerDTO workerGeneralInfoDTO);

        public void Remove(int id);

        public WorkerDTO GetById(int id);

        public IEnumerable<WorkerDTO> GetAll();
    }
}
