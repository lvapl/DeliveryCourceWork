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

            AddressMapper.Map(addressDTO, address);

            _addressRepository.Add(address);
        }

        public void Edit(AddressDTO addressDTO)
        {
            Address address = _addressRepository.GetById(addressDTO.Id);
            AddressMapper.Map(addressDTO, address);

            _addressRepository.Edit(address);
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            return AddressMapper.MapAll(_addressRepository.GetAll());
        }

        public AddressDTO GetById(int id)
        {
            return AddressMapper.Map(_addressRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _addressRepository.Remove(id);
        }
    }
}
