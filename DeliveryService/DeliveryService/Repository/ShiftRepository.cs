using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private DsContext _context;

        public ShiftRepository(DsContext context)
        {
            _context = context;
        }

        public void Add(Shift shift)
        {
            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void Edit(Shift shift)
        {
            _context.Shifts.Update(shift);
            _context.SaveChanges();
        }

        public IEnumerable<Shift> GetAll()
        {
            return _context.Shifts.ToList();
        }

        public Shift GetById(int id)
        {
            return _context.Shifts.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            _context.Shifts.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
