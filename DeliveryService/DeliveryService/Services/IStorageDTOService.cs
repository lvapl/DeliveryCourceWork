using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="StorageDTO"/>.
    /// </summary>
    public interface IStorageDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="storageDto">Добавляемый элемент.</param>
        public void Add(StorageDTO storageDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="storageDto">Редактирует существующий элемент.</param>
        public void Edit(StorageDTO storageDto);

        /// <summary>
        /// Удаляет элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого элемента.</param>
        public void Remove(int id);

        /// <summary>
        /// Возвращает элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Найденный элемент.</returns>
        public StorageDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        public IEnumerable<StorageDTO> GetAll();
    }
}
