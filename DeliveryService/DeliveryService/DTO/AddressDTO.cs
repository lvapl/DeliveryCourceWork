using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StreetId { get; set; }

        public int? HouseId { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? House { get; set; }

        public int Postcode { get; set; }
    }
}
