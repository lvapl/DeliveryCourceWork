using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private DsContext _context;

        public DeliveryRepository(DsContext context)
        {
            _context = context;
        }

        public void Add(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }

        public void Edit(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
        }

        public IEnumerable<Delivery> GetAll()
        {
            return _context.Deliveries.ToList();
        }

        public Delivery GetById(int id)
        {
            return _context.Deliveries.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            _context.Deliveries.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
