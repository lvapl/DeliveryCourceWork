using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            EntityEntry<Position> entry = _context.Entry(position);
            try
            {
                _context.Positions.Add(position);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Position position)
        {
            EntityEntry<Position> entry = _context.Entry(position);
            try
            {
                _context.Positions.Update(position);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
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
            Position position = GetById(id);
            EntityEntry<Position> entry = _context.Entry(position);
            try
            {
                _context.Remove(position);
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
