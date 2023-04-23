using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    public static class StorageMapper
    {
        public static StorageDTO Map(Storage storage)
        {
            return new StorageDTO 
            {
                Id = storage.Id,
                Title = storage.Title,
                Address = storage.Address == null ? null : AddressMapper.Map(storage.Address)
            };
        }

        public static void Map(StorageDTO storageDto, Storage storage)
        {
            storage.Title = storageDto.Title;

            if (storageDto.Address != null)
            {
                AddressMapper.Map(storageDto.Address, storage.Address ?? (storage.Address = new Address()));
            }  
        }

        public static IEnumerable<StorageDTO> MapAll(IEnumerable<Storage> storages)
        {
            return storages.ToList().ConvertAll(Map);
        }
    }
}
