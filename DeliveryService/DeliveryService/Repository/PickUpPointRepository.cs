using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="PickUpPoint"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class PickUpPointRepository : IPickUpPointRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public PickUpPointRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
        public void Add(PickUpPoint point)
        {
            EntityEntry<PickUpPoint> entry = _context.Entry(point);
            try
            {
                _context.PickUpPoints.Add(point);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(PickUpPoint point)
        {
            EntityEntry<PickUpPoint> entry = _context.Entry(point);
            try
            {
                _context.PickUpPoints.Update(point);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
        }

        public IEnumerable<PickUpPoint> GetAll()
        {
            return _context.PickUpPoints.ToList();
        }

        public PickUpPoint GetById(int id)
        {
            return _context.PickUpPoints.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            PickUpPoint point = GetById(id);
            EntityEntry<PickUpPoint> entry = _context.Entry(point);
            try
            {
                _context.PickUpPoints.Remove(point);
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
