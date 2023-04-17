using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IUserDTOService
    {
        public void Add(UserDTO userDTO);

        public void Edit(UserDTO userDTO);

        public void Remove(int id);

        public UserDTO GetById(int id);

        public IEnumerable<UserDTO> GetAll();
    }
}
