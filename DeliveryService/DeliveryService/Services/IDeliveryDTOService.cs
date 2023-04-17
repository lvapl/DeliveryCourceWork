using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IDeliveryDTOService
    {
        void Add(DeliveryDTO deliveryDTO);
        void Edit(DeliveryDTO deliveryDTO);
        void Remove(int id);
        DeliveryDTO GetById(int id);
        IEnumerable<DeliveryDTO> GetAll();
    }
}
