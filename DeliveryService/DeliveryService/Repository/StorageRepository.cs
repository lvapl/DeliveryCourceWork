using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private DsContext _context;

        public StorageRepository(DsContext context)
        {
            _context = context;
        }

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
    }
}
