using AutoMapper;
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
        private IMapper _mapper;
        private IWorkerRepository _workerRepository;

        public WorkerGeneralInfoService( IMapper mapper, IWorkerRepository workerRepository)
        {
            _mapper = mapper;
            _workerRepository = workerRepository;
        }

        public void Add(WorkerGeneralInfoDTO workerGeneralInfoDTO)
        {
            Worker worker = new Worker();
        }

        public void Edit(WorkerGeneralInfoDTO workerGeneralInfoDTO)
        {
            Worker worker = _workerRepository.GetById(workerGeneralInfoDTO.Id);

            _workerRepository.Edit(_mapper.Map(workerGeneralInfoDTO, worker));
        }

        public void Remove(int id)
        {
            _workerRepository.Remove(id);
        }

        public WorkerGeneralInfoDTO GetById(int id)
        {
            return _mapper.Map<WorkerGeneralInfoDTO>(_workerRepository.GetById(id));
        }

        public IEnumerable<WorkerGeneralInfoDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<WorkerGeneralInfoDTO>>(_workerRepository.GetAll());
        }
    }
}
