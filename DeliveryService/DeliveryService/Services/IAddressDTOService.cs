using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IAddressDTOService
    {
        public void Add(AddressDTO addressDto);

        public void Edit(AddressDTO addressDto);

        public void Remove(int id);

        public AddressDTO GetById(int id);

        public IEnumerable<AddressDTO> GetAll();
    }
}
