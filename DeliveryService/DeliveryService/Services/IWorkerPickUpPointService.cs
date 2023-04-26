using DeliveryService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="AddressDTO"/>.
    /// </summary>
    public interface IWorkerPickUpPointService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="workersInPickUpPointsDTO">Добавляемый элемент.</param>
        void Add(WorkersInPickUpPointsDTO workersInPickUpPointsDTO);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="workersInPickUpPointsDTO">Редактирует существующий элемент.</param>
        void Edit(WorkersInPickUpPointsDTO workersInPickUpPointsDTO);

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
        WorkersInPickUpPointsDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<WorkersInPickUpPointsDTO> GetAll();
    }
}
