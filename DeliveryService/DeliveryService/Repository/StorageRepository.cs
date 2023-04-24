using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

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
            _context.Storages.Add(storage);
            _context.SaveChanges();
        }

        public void Edit(Storage storage)
        {
            _context.Storages.Update(storage);
            _context.SaveChanges();
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
            _context.Storages.Remove(GetById(id));
            _context.SaveChanges();
        }
        #endregion
    }
}
