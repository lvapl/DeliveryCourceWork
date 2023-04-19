using DeliveryService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IStorageDTOService
    {
        public void Add(StorageDTO storageDTO);

        public void Edit(StorageDTO storageDTO);

        public void Remove(int id);

        public StorageDTO GetById(int id);

        public IEnumerable<StorageDTO> GetAll();
    }
}
