using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            EntityEntry<Delivery> entry = _context.Entry(delivery);
            try
            {
                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Delivery delivery)
        {
            EntityEntry<Delivery> entry = _context.Entry(delivery);
            try
            {
                _context.Deliveries.Update(delivery);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
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
            Delivery delivery = GetById(id);
            EntityEntry<Delivery> entry = _context.Entry(delivery);
            try
            {
                _context.Deliveries.Remove(delivery);
                _context.SaveChanges();
            }
            catch 
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно присутствуют связи с другими записями.");
            }
        }
        #endregion
    }
}
