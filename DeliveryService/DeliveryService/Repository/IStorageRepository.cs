using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IStorageRepository
    {
        void Add(Storage storage);
        void Edit(Storage storage);
        void Remove(int id);
        Storage GetById(int id);
        IEnumerable<Storage> GetAll();
    }
}
