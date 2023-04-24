using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="Delivery"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class DeliveryRepository : IDeliveryRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public DeliveryRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
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
        #endregion
    }
}
