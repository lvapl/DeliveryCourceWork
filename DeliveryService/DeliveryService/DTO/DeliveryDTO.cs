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
    public class DeliveryDTO
    {
        public int Id { get; set; }

        public int? TariffId { get; set; }

        public string? TariffTitle { get; set; }

        public decimal? Price { get; set; }

        public int? SenderId { get; set; }

        public int? RecipientId { get; set; }

        public UserDTO? Sender { get; set; }

        public UserDTO? Recipient { get; set; }

        public int? PickPointId { get; set; }

        public int? UpPointId { get; set; }
    }
}
