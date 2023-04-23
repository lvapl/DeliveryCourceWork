using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IDeliveryDTOService
    {
        void Add(DeliveryDTO deliveryDto);
        void Edit(DeliveryDTO deliveryDto);
        void Remove(int id);
        DeliveryDTO GetById(int id);
        IEnumerable<DeliveryDTO> GetAll();
    }
}
