using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="WorkersInPickUpPoint"/>.
    /// </summary>
    public interface IWorkerPickUpPointRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="workersInPickUpPoint">Добавляемый элемент.</param>
        void Add(WorkersInPickUpPoint workersInPickUpPoint);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="workersInPickUpPoint">Редактируемый элемент.</param>
        void Edit(WorkersInPickUpPoint workersInPickUpPoint);

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
        WorkersInPickUpPoint GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<WorkersInPickUpPoint> GetAll();
    }
}
