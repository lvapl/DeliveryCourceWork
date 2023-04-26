using System;
using System.Net;
using DeliveryService.Enums;
using DeliveryService.Model;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс, представляющий сервис аутентификации пользователей.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Аутентификация сотрудника.
        /// </summary>
        /// <param name="credential">Учетные данные сотрудника.</param>
        /// <returns>Объект сотрудника, если аутентификация прошла успешно, иначе - null.</returns>
        public Worker? AuthenticateWorker(NetworkCredential credential);

        /// <summary>
        /// Проверка доступа к странице приложения.
        /// </summary>
        /// <param name="section">Страница приложения.</param>
        /// <returns>True, если пользователь имеет доступ к странице, иначе - false.</returns>
        public bool HasAccessToSection(AppPages section);

        /// <summary>
        /// Проверка доступа к подразделу страницы приложения.
        /// </summary>
        /// <typeparam name="T">Тип перечисления подразделов страницы приложения.</typeparam>
        /// <param name="subSection">Подраздел страницы приложения.</param>
        /// <returns>True, если пользователь имеет доступ к подразделу, иначе - false.</returns>
        public bool HasAccessToSubSection<T>(T subSection) where T: Enum;

        /// <summary>
        /// Проверка прав на изменение подраздела страницы приложения.
        /// </summary>
        /// <typeparam name="T">Тип DTO-объекта подраздела страницы приложения.</typeparam>
        /// <param name="dtoSubSection">DTO-объект подраздела страницы приложения.</param>
        /// <returns>True, если пользователь имеет права на изменение подраздела, иначе - false.</returns>
        public bool HasPermissionToModifySubsection<T>(T dtoSubSection) where T : Enum;
    }
}
