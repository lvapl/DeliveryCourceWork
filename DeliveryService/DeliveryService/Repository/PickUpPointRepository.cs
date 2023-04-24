using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

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
            _context.PickUpPoints.Add(point);
            _context.SaveChanges();
        }

        public void Edit(PickUpPoint point)
        {
            _context.PickUpPoints.Update(point);
            _context.SaveChanges();
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
            _context.PickUpPoints.Remove(GetById(id));
        }
        #endregion
    }
}
