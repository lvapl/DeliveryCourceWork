using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="Storage"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class StorageRepository : IStorageRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public StorageRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
        public void Add(Storage storage)
        {
            EntityEntry<Storage> entry = _context.Entry(storage);
            try
            {
                _context.Storages.Add(storage);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Storage storage)
        {
            EntityEntry<Storage> entry = _context.Entry(storage);
            try
            {
                _context.Storages.Update(storage);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
        }

        public IEnumerable<Storage> GetAll()
        {
            return _context.Storages.ToList();
        }

        public Storage GetById(int id)
        {
            return _context.Storages.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            Storage storage = GetById(id);
            EntityEntry<Storage> entry = _context.Entry(storage);
            try
            {
                _context.Storages.Remove(storage);
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
