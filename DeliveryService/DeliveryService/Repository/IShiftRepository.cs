using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Shift"/>.
    /// </summary>
    public interface IShiftRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="shift">Добавляемый элемент.</param>
        void Add(Shift shift);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="shift">Редактируемый элемент.</param>
        void Edit(Shift shift);

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
        Shift GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Shift> GetAll();
    }
}
