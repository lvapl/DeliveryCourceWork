using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="Position"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public PositionRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
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
            return _context.Positions.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }
        #endregion
    }
}
