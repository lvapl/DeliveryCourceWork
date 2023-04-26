using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="PickUpPointDTO"/>.
    /// </summary>
    public interface IPickUpPointDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="pickUpPointDto">Добавляемый элемент.</param>
        public void Add(PickUpPointDTO pickUpPointDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="pickUpPointDto">Редактирует существующий элемент.</param>
        public void Edit(PickUpPointDTO pickUpPointDto);

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
        public PickUpPointDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        public IEnumerable<PickUpPointDTO> GetAll();
    }
}
