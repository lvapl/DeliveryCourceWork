using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IUserDTOService
    {
        public void Add(UserDTO userDto);

        public void Edit(UserDTO userDto);

        public void Remove(int id);

        public UserDTO GetById(int id);

        public IEnumerable<UserDTO> GetAll();
    }
}
