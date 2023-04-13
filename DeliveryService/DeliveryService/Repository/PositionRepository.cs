using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private DsContext _context;

        public PositionRepository(DsContext context)
        {
            _context = context;
        }

        public void Add(Position position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
        }

        public void Edit(Position position)
        {
            _context.Positions.Update(position);
            _context.SaveChanges();
        }

        public IEnumerable<Position> GetAll()
        {
            return _context.Positions.ToList();
        }

        public Position GetById(int id)
        {
            return _context.Positions.Find(id) ?? throw new ArgumentNullException();
        }

        public void Remove(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
