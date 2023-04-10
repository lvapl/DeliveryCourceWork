using AutoMapper;
using DeliveryService.Mappers;
using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public class WorkerGeneralInfoService : IWorkerGeneralInfoService
    {
        private IWorkerRepository _workerRepository;

        public WorkerGeneralInfoService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public void Add(WorkerGeneralInfoDTO workerGeneralInfoDTO)
        {
            Worker worker = new Worker();
            WorkerMapper.Map(workerGeneralInfoDTO, worker);
            _workerRepository.Add(worker);
        }

        public void Edit(WorkerGeneralInfoDTO workerGeneralInfoDTO)
        {
            Worker worker = _workerRepository.GetById(workerGeneralInfoDTO.Id);
            WorkerMapper.Map(workerGeneralInfoDTO, worker);
            _workerRepository.Edit(worker);
        }

        public void Remove(int id)
        {
            _workerRepository.Remove(id);
        }

        public WorkerGeneralInfoDTO GetById(int id)
        {
            return WorkerMapper.Map(_workerRepository.GetById(id));
        }

        public IEnumerable<WorkerGeneralInfoDTO> GetAll()
        {
            return WorkerMapper.MapAll(_workerRepository.GetAll());
        }
    }
}
