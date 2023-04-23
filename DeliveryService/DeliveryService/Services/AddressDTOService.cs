using System.Collections.Generic;
using DeliveryService.DTO;
using DeliveryService.Mappers;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class AddressDTOService : IAddressDTOService
    {
        private IAddressRepository _addressRepository;

        public AddressDTOService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Add(AddressDTO addressDto)
        {
            Address address = new Address();

            AddressMapper.Map(addressDto, address);

            _addressRepository.Add(address);
        }

        public void Edit(AddressDTO addressDto)
        {
            Address address = _addressRepository.GetById(addressDto.Id);
            AddressMapper.Map(addressDto, address);

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
