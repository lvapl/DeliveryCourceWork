using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public class PickUpPointRepository : IPickUpPointRepository
    {
        private DsContext _context;

        public PickUpPointRepository(DsContext context)
        {
            _context = context;
        }

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
    }
}
