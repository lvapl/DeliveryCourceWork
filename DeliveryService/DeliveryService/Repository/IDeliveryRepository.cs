using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
