using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Delivery"/>.
    /// </summary>
    public interface IDeliveryRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="delivery">Добавляемый элемент.</param>
        void Add(Delivery delivery);
        
        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="delivery">Редактируемый элемент.</param>
        void Edit(Delivery delivery);
        
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
        Delivery GetById(int id);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Delivery> GetAll();
    }
}
