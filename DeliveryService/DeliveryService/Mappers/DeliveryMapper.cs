using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class DeliveryMapper
    {
        private static DsContext _context = App.ServiceProvider.GetRequiredService<DsContext>();

        private static IAddressRepository _addressRepository = App.ServiceProvider.GetRequiredService<IAddressRepository>();

        public static DeliveryDTO Map(Delivery delivery)
        {
            return new DeliveryDTO
            {
                Id = delivery.Id,
                TariffId = delivery.TariffId,
                TariffTitle = delivery.Tariff == null ? null : delivery.Tariff.Title,
                Price = delivery.Price,
                SenderId = delivery.SenderId == null ? null : delivery.SenderId,
                RecipientId = delivery.RecipientId == null ? null : delivery.RecipientId,
                PickPointId = delivery.PickPoint,
                UpPointId = delivery.UpPoint,
                Sender = delivery.Sender == null ? null : UserMapper.Map(delivery.Sender),
                Recipient = delivery.Recipient == null ? null : UserMapper.Map(delivery.Recipient)
            };
        }

        public static void Map(DeliveryDTO deliveryDTO, Delivery delivery)
        {
            delivery.TariffId = deliveryDTO.TariffId;
            delivery.Price = deliveryDTO.Price;
            delivery.PickPoint = deliveryDTO.PickPointId;
            delivery.UpPoint = deliveryDTO.UpPointId;
            delivery.SenderId = deliveryDTO.SenderId;
            delivery.RecipientId = deliveryDTO.RecipientId;
        }

        public static IEnumerable<DeliveryDTO> MapAll(IEnumerable<Delivery> deliveries)
        {
            return deliveries.ToList().ConvertAll<DeliveryDTO>(x => Map(x));
        }
    }
}
