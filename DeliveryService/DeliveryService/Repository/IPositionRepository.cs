using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Position"/>.
    /// </summary>
    public interface IPositionRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="position">Добавляемый элемент.</param>
        void Add(Position position);
        
        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="position">Редактируемый элемент.</param>
        void Edit(Position position);
        
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
        Position GetById(int id);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Position> GetAll();
    }
}
