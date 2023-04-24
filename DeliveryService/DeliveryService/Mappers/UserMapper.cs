using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    /// <summary>
    /// Класс для преобразования модели <see cref="User"/> в <see cref="UserDTO"/> и обратно.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Метод для преобразования <see cref="User"/> в <see cref="UserDTO"/>.
        /// </summary>
        /// <param name="user">Модель <see cref="User"/> по которой нужно выполнить преобразование.</param>
        /// <returns>DTO объект <see cref="UserDTO"/>, полученный в результате преобразования.</returns>
        public static UserDTO Map(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Patronymic = user.Patronymic,
                PassportNumber = user.PassportNumber,
                PassportSeries = user.PassportSeries,
                TelephoneNumber = user.TelephoneNumber,
                Address = user.Address == null ? null : AddressMapper.Map(user.Address),
                PassportAddress = user.PassportAddressNavigation == null ? null : AddressMapper.Map(user.PassportAddressNavigation)
            };
        }

        /// <summary>
        /// Метод для преобразования объекта <see cref="UserDTO"/> в <see cref="User"/>.
        /// </summary>
        /// <param name="userDto">DTO объект <see cref="UserDTO"/> по которому нужно выполнить преобразование.</param>
        /// <param name="user">Модель <see cref="User"/>, полученная в результате преобразования.</param>
        public static void Map(UserDTO userDto, User user)
        {
            user.Firstname = userDto.FirstName;
            user.Lastname = userDto.LastName;
            user.Patronymic = userDto.Patronymic;
            user.TelephoneNumber = userDto.TelephoneNumber;
            user.PassportSeries = userDto.PassportSeries;
            user.PassportNumber = userDto.PassportNumber;
            if (userDto.Address != null)
            {
                AddressMapper.Map(userDto.Address, (user.Address = new Address()));
            }
            if (userDto.PassportAddress != null)
            {
                AddressMapper.Map(userDto.PassportAddress, (user.PassportAddressNavigation = new Address()));
            }
        }

        /// <summary>
        /// Метод для преобразования коллекции <see cref="User"/> в коллекцию <see cref="UserDTO"/>.
        /// </summary>
        /// <param name="users">Коллекция <see cref="User"/>, которую нужно отобразить.</param>
        /// <returns>Коллекция <see cref="UserDTO"/>, полученная в результате преобразования.</returns>
        public static IEnumerable<UserDTO> MapAll(IEnumerable<User> users)
        {
            return users.ToList().ConvertAll(Map);
        }
    }
}
