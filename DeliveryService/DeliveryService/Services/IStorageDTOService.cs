using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IStorageDTOService
    {
        public void Add(StorageDTO storageDto);

        public void Edit(StorageDTO storageDto);

        public void Remove(int id);

        public StorageDTO GetById(int id);

        public IEnumerable<StorageDTO> GetAll();
    }
}
