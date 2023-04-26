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
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Patronymic { get; set; }

        public AddressDTO? Address { get; set; }

        public AddressDTO? PassportAddress { get; set; }

        public int PassportNumber { get; set; }

        public int PassportSeries { get; set; }

        public string TelephoneNumber { get; set; } = null!;
    }
}
