using DeliveryService.DTO;
using DeliveryService.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class UserMapper
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

        public static void Map(UserDTO userDTO, User user)
        {
            user.Firstname = userDTO.FirstName;
            user.Lastname = userDTO.LastName;
            user.Patronymic = userDTO.Patronymic;
            user.TelephoneNumber = userDTO.TelephoneNumber;
            user.PassportSeries = userDTO.PassportSeries;
            user.PassportNumber = userDTO.PassportNumber;
            if (userDTO.Address != null)
            {
                AddressMapper.Map(userDTO.Address, user.Address ?? (user.Address = new Address()));
            }
            if (userDTO.PassportAddress != null)
            {
                AddressMapper.Map(userDTO.PassportAddress, user.PassportAddressNavigation ?? (user.PassportAddressNavigation = new Address()));
            }
        }

        public static IEnumerable<UserDTO> MapAll(IEnumerable<User> users)
        {
            return users.ToList().ConvertAll<UserDTO>(x => Map(x));
        }
    }
}
