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
    public class PickUpPointDTOService : IPickUpPointDTOService
    {
        private IPickUpPointRepository _pickUpPointRepository;

        public PickUpPointDTOService(IPickUpPointRepository pickUpPointRepository)
        {
            _pickUpPointRepository = pickUpPointRepository;
        }

        public void Add(PickUpPointDTO pickUpPointDTO)
        {
            PickUpPoint pickUpPoint = new PickUpPoint();

            PickUpPointMapper.Map(pickUpPointDTO, pickUpPoint);
            _pickUpPointRepository.Add(pickUpPoint);
        }

        public void Edit(PickUpPointDTO pickUpPointDTO)
        {
            PickUpPoint pickUpPoint = _pickUpPointRepository.GetById(pickUpPointDTO.Id);

            PickUpPointMapper.Map(pickUpPointDTO, pickUpPoint);
            _pickUpPointRepository.Edit(pickUpPoint);
        }

        public IEnumerable<PickUpPointDTO> GetAll()
        {
            return PickUpPointMapper.MapAll(_pickUpPointRepository.GetAll());
        }

        public PickUpPointDTO GetById(int id)
        {
            return PickUpPointMapper.Map(_pickUpPointRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _pickUpPointRepository.Remove(id);
        }
    }
}
