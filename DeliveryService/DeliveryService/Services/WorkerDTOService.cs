using AutoMapper;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public class WorkerDTOService : IWorkerDTOService
    {
        private IWorkerRepository _workerRepository;

        public WorkerDTOService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public void Add(WorkerDTO workerGeneralInfoDTO)
        {
            Worker worker = new Worker();
            User user = new User();

            worker.IdNavigation = user;
            WorkerMapper.Map(workerGeneralInfoDTO, worker);
            _workerRepository.Add(worker);
        }

        public void Edit(WorkerDTO workerGeneralInfoDTO)
        {
            Worker worker = _workerRepository.GetById(workerGeneralInfoDTO.Id);
            WorkerMapper.Map(workerGeneralInfoDTO, worker);
            _workerRepository.Edit(worker);
        }

        public void Remove(int id)
        {
            _workerRepository.Remove(id);
        }

        public WorkerDTO GetById(int id)
        {
            return WorkerMapper.Map(_workerRepository.GetById(id));
        }

        public IEnumerable<WorkerDTO> GetAll()
        {
            return WorkerMapper.MapAll(_workerRepository.GetAll());
        }
    }
}
