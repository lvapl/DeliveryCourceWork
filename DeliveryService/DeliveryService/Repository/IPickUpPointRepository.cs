using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IPickUpPointRepository
    {
        void Add(PickUpPoint point);
        void Edit(PickUpPoint point);
        void Remove(int id);
        PickUpPoint GetById(int id);
        IEnumerable<PickUpPoint> GetAll();
    }
}
