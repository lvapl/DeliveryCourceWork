using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IDeliveryRepository
    {
        void Add(Delivery delivery);
        void Edit(Delivery delivery);
        void Remove(int id);
        Delivery GetById(int id);
        IEnumerable<Delivery> GetAll();
    }
}
