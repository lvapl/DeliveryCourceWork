using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public class StorageDTOService : IStorageDTOService
    {
        private IStorageRepository _storageRepository;

        public StorageDTOService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public void Add(StorageDTO storageDTO)
        {
            Storage storage = new Storage();

            StorageMapper.Map(storageDTO, storage);
            _storageRepository.Add(storage);
        }

        public void Edit(StorageDTO storageDTO)
        {
            Storage storage = _storageRepository.GetById(storageDTO.Id);

            StorageMapper.Map(storageDTO, storage);
            _storageRepository.Edit(storage);
        }

        public IEnumerable<StorageDTO> GetAll()
        {
            return StorageMapper.MapAll(_storageRepository.GetAll());
        }

        public StorageDTO GetById(int id)
        {
            return StorageMapper.Map(_storageRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _storageRepository.Remove(id);
        }
    }
}
