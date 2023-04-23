using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class DeliveryDTOService : IDeliveryDTOService
    {
        private IDeliveryRepository _repository;

        public DeliveryDTOService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public void Add(DeliveryDTO deliveryDto)
        {
            Delivery delivery = new Delivery();

            DeliveryMapper.Map(deliveryDto, delivery);

            _repository.Add(delivery);
        }

        public void Edit(DeliveryDTO deliveryDto)
        {
            Delivery delivery = _repository.GetById(deliveryDto.Id);

            DeliveryMapper.Map(deliveryDto, delivery);

            _repository.Edit(delivery);
        }

        public IEnumerable<DeliveryDTO> GetAll()
        {
            return DeliveryMapper.MapAll(_repository.GetAll());
        }

        public DeliveryDTO GetById(int id)
        {
            return DeliveryMapper.Map(_repository.GetById(id));
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
