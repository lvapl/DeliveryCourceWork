using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class UserDTOService : IUserDTOService
    {
        private IUserRepository _userRepository;

        public UserDTOService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDTO userDto)
        {
            User user = new User();

            UserMapper.Map(userDto, user);
            _userRepository.Add(user);
        }

        public void Edit(UserDTO userDto)
        {
            User user = _userRepository.GetById(userDto.Id);
            UserMapper.Map(userDto, user);
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
