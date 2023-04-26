using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="DeliveryDTO"/>.
    /// </summary>
    public interface IDeliveryDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="deliveryDto">Добавляемый элемент.</param>
        void Add(DeliveryDTO deliveryDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="deliveryDto">Редактирует существующий элемент.</param>
        void Edit(DeliveryDTO deliveryDto);

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
        DeliveryDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<DeliveryDTO> GetAll();
    }
}
