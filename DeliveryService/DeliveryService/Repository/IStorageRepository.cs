using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Storage"/>.
    /// </summary>
    public interface IStorageRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="storage">Добавляемый элемент.</param>
        void Add(Storage storage);
        
        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="storage">Редактируемый элемент.</param>
        void Edit(Storage storage);
        
        /// <summary>
        /// Удаляет элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого элемента.</param>
        void Remove(int id);
        
        /// <summary>
        /// Возвращает элемент по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Найденный элемент.</returns>
        Storage GetById(int id);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Storage> GetAll();
    }
}
