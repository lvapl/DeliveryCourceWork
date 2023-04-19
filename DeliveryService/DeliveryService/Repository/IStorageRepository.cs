using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
