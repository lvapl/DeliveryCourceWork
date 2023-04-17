using AutoMapper;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public class UserDTOService : IUserDTOService
    {
        private IUserRepository _userRepository;

        public UserDTOService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDTO userDTO)
        {
            User user = new User();

            UserMapper.Map(userDTO, user);
            _userRepository.Add(user);
        }

        public void Edit(UserDTO userDTO)
        {
            User user = _userRepository.GetById(userDTO.Id);
            UserMapper.Map(userDTO, user);
            _userRepository.Edit(user);
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
        }

        public UserDTO GetById(int id)
        {
            return UserMapper.Map(_userRepository.GetById(id));
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return UserMapper.MapAll(_userRepository.GetAll());
        }
    }
}
