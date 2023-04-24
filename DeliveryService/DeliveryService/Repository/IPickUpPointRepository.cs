using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="PickUpPoint"/>.
    /// </summary>
    public interface IPickUpPointRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="point">Добавляемый элемент.</param>
        void Add(PickUpPoint point);
        
         /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="point">Редактируемый элемент.</param>
        void Edit(PickUpPoint point);

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
        PickUpPoint GetById(int id);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<PickUpPoint> GetAll();
    }
}
