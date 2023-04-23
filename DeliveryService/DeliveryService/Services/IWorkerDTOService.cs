using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IWorkerDTOService
    {
        public void Add(WorkerDTO workerGeneralInfoDto);

        public void Edit(WorkerDTO workerGeneralInfoDto);

        public void Remove(int id);

        public WorkerDTO GetById(int id);

        public IEnumerable<WorkerDTO> GetAll();
    }
}
