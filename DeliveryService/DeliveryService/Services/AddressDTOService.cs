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
    public class AddressDTOService : IAddressDTOService
    {
        private IAddressRepository _addressRepository;

        public AddressDTOService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Add(AddressDTO addressDTO)
        {
            Address address = new Address();

        }

        public void Edit(AddressDTO addressDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AddressDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
