using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DTO
{
    /// <summary>
    /// Объект служащий для отображения и изменения необходимых данных.
    /// </summary>
    public class PickUpPointDTO
    {
        public int Id { get; set; }

        public AddressDTO? Address { get; set; }
    }
}
