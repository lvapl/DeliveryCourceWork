using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    public static class UserMapper
    {
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

        public static IEnumerable<UserDTO> MapAll(IEnumerable<User> users)
        {
            return users.ToList().ConvertAll(Map);
        }
    }
}
