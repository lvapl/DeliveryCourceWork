using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
