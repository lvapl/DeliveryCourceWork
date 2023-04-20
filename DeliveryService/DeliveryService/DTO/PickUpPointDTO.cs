using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DTO
{
    public class PickUpPointDTO
    {
        public int Id { get; set; }

        public AddressDTO? Address { get; set; }
    }
}
