using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Интерфейс репозитория модели <see cref="Worker"/>.
    /// </summary>
    public interface IWorkerRepository
    {
        /// <summary>
        /// Добавляет новый элемент.
        /// </summary>
        /// <param name="address">Добавляемый элемент.</param>
        void Add(Worker worker);
        
        /// <summary>
        /// Редактирует существующий элемент.
        /// </summary>
        /// <param name="address">Редактируемый элемент.</param>
        void Edit(Worker worker);
        
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
        Worker GetById(int id);
        
        /// <summary>
        /// Возвращает элемент по логину и паролю.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Найденный элемент или null.</returns>
        Worker? GetWorkerByLoginAndPassword(string login, byte[] password);
        
        /// <summary>
        /// Возвращает все элементы.
        /// </summary>
        /// <returns>Коллекция всех элементов.</returns>
        IEnumerable<Worker> GetAll();
    }
}
