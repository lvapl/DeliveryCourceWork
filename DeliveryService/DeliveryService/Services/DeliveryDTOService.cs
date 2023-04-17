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
    public class DeliveryDTOService : IDeliveryDTOService
    {
        private IDeliveryRepository _repository;

        public DeliveryDTOService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public void Add(DeliveryDTO deliveryDTO)
        {
            Delivery delivery = new Delivery();

            DeliveryMapper.Map(deliveryDTO, delivery);

            _repository.Add(delivery);
        }

        public void Edit(DeliveryDTO deliveryDTO)
        {
            Delivery delivery = _repository.GetById(deliveryDTO.Id);

            DeliveryMapper.Map(deliveryDTO, delivery);

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
