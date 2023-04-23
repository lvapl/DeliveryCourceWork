using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class StorageDTOService : IStorageDTOService
    {
        private IStorageRepository _storageRepository;

        public StorageDTOService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public void Add(StorageDTO storageDto)
        {
            Storage storage = new Storage();

            StorageMapper.Map(storageDto, storage);
            _storageRepository.Add(storage);
        }

        public void Edit(StorageDTO storageDto)
        {
            Storage storage = _storageRepository.GetById(storageDto.Id);

            StorageMapper.Map(storageDto, storage);
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
