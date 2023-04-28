using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            EntityEntry<Shift> entry = _context.Entry(shift);
            try
            {
                _context.Shifts.Add(shift);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Shift shift)
        {
            EntityEntry<Shift> entry = _context.Entry(shift);
            try
            {
                _context.Shifts.Update(shift);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
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
            Shift shift = GetById(id);
            EntityEntry<Shift> entry = _context.Entry(shift);
            try
            {
                _context.Shifts.Remove(shift);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно присутствуют связи с другими записями.");
            }
        }
    }
}
