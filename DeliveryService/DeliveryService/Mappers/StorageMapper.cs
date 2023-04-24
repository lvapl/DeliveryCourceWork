using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    /// <summary>
    /// Класс для преобразования модели <see cref="Storage"/> в <see cref="StorageDTO"/> и обратно.
    /// </summary>
    public static class StorageMapper
    {
        /// <summary>
        /// Метод для преобразования <see cref="Storage"/> в <see cref="StorageDTO"/>.
        /// </summary>
        /// <param name="storage">Модель <see cref="Storage"/> по которой нужно выполнить преобразование.</param>
        /// <returns>DTO объект <see cref="StorageDTO"/>, полученный в результате преобразования.</returns>
        public static StorageDTO Map(Storage storage)
        {
            return new StorageDTO 
            {
                Id = storage.Id,
                Title = storage.Title,
                Address = storage.Address == null ? null : AddressMapper.Map(storage.Address)
            };
        }

        /// <summary>
        /// Метод для преобразования объекта <see cref="StorageDTO"/> в <see cref="Storage"/>.
        /// </summary>
        /// <param name="storageDto">DTO объект <see cref="StorageDTO"/> по которому нужно выполнить преобразование.</param>
        /// <param name="storage">Модель <see cref="Storage"/>, полученная в результате преобразования.</param>
        public static void Map(StorageDTO storageDto, Storage storage)
        {
            storage.Title = storageDto.Title;

            if (storageDto.Address != null)
            {
                AddressMapper.Map(storageDto.Address, storage.Address ?? (storage.Address = new Address()));
            }  
        }

        /// <summary>
        /// Метод для преобразования коллекции <see cref="Storage"/> в коллекцию <see cref="StorageDTO"/>.
        /// </summary>
        /// <param name="storages">Коллекция <see cref="Storage"/>, которую нужно отобразить.</param>
        /// <returns>Коллекция <see cref="StorageDTO"/>, полученная в результате преобразования.</returns>
        public static IEnumerable<StorageDTO> MapAll(IEnumerable<Storage> storages)
        {
            return storages.ToList().ConvertAll(Map);
        }
    }
}
