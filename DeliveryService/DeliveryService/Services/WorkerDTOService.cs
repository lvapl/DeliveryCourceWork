using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class WorkerDTOService : IWorkerDTOService
    {
        private IWorkerRepository _workerRepository;
        private IUserRepository _userRepository;

        public WorkerDTOService(IWorkerRepository workerRepository, IUserRepository userRepository)
        {
            _workerRepository = workerRepository;
            _userRepository = userRepository;
        }

        public void Add(WorkerDTO workerGeneralInfoDto)
        {
            Worker worker = new Worker();
            User user = new User();

            worker.IdNavigation = user;
            WorkerMapper.Map(workerGeneralInfoDto, worker);

            _userRepository.Add(user);
            worker.Id = user.Id;

            _workerRepository.Add(worker);
        }

        public void Edit(WorkerDTO workerGeneralInfoDto)
        {
            Worker worker = _workerRepository.GetById(workerGeneralInfoDto.Id);
            WorkerMapper.Map(workerGeneralInfoDto, worker);
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
