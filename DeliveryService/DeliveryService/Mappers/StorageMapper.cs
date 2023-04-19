using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class StorageMapper
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

        public static void Map(StorageDTO storageDTO, Storage storage)
        {
            storage.Title = storageDTO.Title;

            if (storageDTO.Address != null)
            {
                AddressMapper.Map(storageDTO.Address, storage.Address ?? (storage.Address = new Address()));
            }  
        }

        public static IEnumerable<StorageDTO> MapAll(IEnumerable<Storage> storages)
        {
            return storages.ToList().ConvertAll<StorageDTO>(x => Map(x));
        }
    }
}
