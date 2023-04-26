using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс сервиса <see cref="UserDTO"/>.
    /// </summary>
    public interface IUserDTOService
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="userDto">Добавляемый элемент.</param>
        public void Add(UserDTO userDto);

        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="userDto">Редактирует существующий элемент.</param>
        public void Edit(UserDTO userDto);

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
        public UserDTO GetById(int id);

        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        public IEnumerable<UserDTO> GetAll();
    }
}
