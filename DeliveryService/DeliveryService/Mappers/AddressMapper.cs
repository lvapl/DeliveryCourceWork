using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class AddressMapper
    {
        public static AddressDTO Map(Address address)
        {
            return new AddressDTO
            {
                Id = address.Id,
                Country = address.Country?.Title,
                City = address.City?.Title,
                Street = address.Street?.Title,
                House = address.House?.Number,
                Postcode = address.Postcode
            };
        }

        public static void Map(AddressDTO addressDTO, Address address)
        {
            address.Postcode = addressDTO.Postcode;
            if (addressDTO.Country != null)
            {
                
                
            }
        }
    }
}
