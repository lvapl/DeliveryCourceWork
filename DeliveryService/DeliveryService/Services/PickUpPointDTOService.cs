using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class PickUpPointDTOService : IPickUpPointDTOService
    {
        private IPickUpPointRepository _pickUpPointRepository;

        public PickUpPointDTOService(IPickUpPointRepository pickUpPointRepository)
        {
            _pickUpPointRepository = pickUpPointRepository;
        }

        public void Add(PickUpPointDTO pickUpPointDto)
        {
            PickUpPoint pickUpPoint = new PickUpPoint();

            PickUpPointMapper.Map(pickUpPointDto, pickUpPoint);
            _pickUpPointRepository.Add(pickUpPoint);
        }

        public void Edit(PickUpPointDTO pickUpPointDto)
        {
            PickUpPoint pickUpPoint = _pickUpPointRepository.GetById(pickUpPointDto.Id);

            PickUpPointMapper.Map(pickUpPointDto, pickUpPoint);
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
