using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="AddressDTO"/>.
    /// </summary>
    public interface IAddressDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="addressDto">Добавляемый элемент.</param>
        public void Add(AddressDTO addressDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="addressDto">Редактирует существующий элемент.</param>
        public void Edit(AddressDTO addressDto);

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
        public AddressDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        public IEnumerable<AddressDTO> GetAll();
    }
}
