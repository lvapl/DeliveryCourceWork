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
    public class WorkerPickUpPointService : IWorkerPickUpPointService
    {
        private IWorkerPickUpPointRepository _workerPointRepository;

        public WorkerPickUpPointService(IWorkerPickUpPointRepository workerPickUpPointRepository)
        {
            _workerPointRepository = workerPickUpPointRepository;
        }

        public void Add(WorkersInPickUpPointsDTO workersInPickUpPointsDTO)
        {
            WorkersInPickUpPoint workersInPickUpPoint = new WorkersInPickUpPoint(); 

            WorkersInPickUpPointsMapper.Map(workersInPickUpPointsDTO, workersInPickUpPoint);
            _workerPointRepository.Add(workersInPickUpPoint);
        }

        public void Edit(WorkersInPickUpPointsDTO workersInPickUpPointsDTO)
        {
            WorkersInPickUpPoint workersInPickUpPoint = _workerPointRepository.GetById(workersInPickUpPointsDTO.Id);

            WorkersInPickUpPointsMapper.Map(workersInPickUpPointsDTO, workersInPickUpPoint);
            _workerPointRepository.Edit(workersInPickUpPoint);
        }

        public IEnumerable<WorkersInPickUpPointsDTO> GetAll()
        {
            return WorkersInPickUpPointsMapper.MapAll(_workerPointRepository.GetAll());
        }

        public WorkersInPickUpPointsDTO GetById(int id)
        {
            return WorkersInPickUpPointsMapper.Map(_workerPointRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _workerPointRepository.Remove(id);
        }
    }
}
