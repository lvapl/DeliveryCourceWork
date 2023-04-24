using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Address"/>.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="address">Добавляемый элемент.</param>
        void Add(Address address);
        
        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="address">Редактируемый элемент.</param>
        void Edit(Address address);
        
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
        Address GetById(int id);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Address> GetAll();
    }
}
