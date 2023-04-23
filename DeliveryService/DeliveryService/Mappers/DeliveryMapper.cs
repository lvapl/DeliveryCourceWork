using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    public static class DeliveryMapper
    {
        public static DeliveryDTO Map(Delivery delivery)
        {
            return new DeliveryDTO
            {
                Id = delivery.Id,
                TariffId = delivery.TariffId,
                TariffTitle = delivery.Tariff?.Title,
                Price = delivery.Price,
                SenderId = delivery.SenderId,
                RecipientId = delivery.RecipientId,
                PickPointId = delivery.PickPoint,
                UpPointId = delivery.UpPoint,
                Sender = delivery.Sender == null ? null : UserMapper.Map(delivery.Sender),
                Recipient = delivery.Recipient == null ? null : UserMapper.Map(delivery.Recipient)
            };
        }

        public static void Map(DeliveryDTO deliveryDto, Delivery delivery)
        {
            delivery.TariffId = deliveryDto.TariffId;
            delivery.Price = deliveryDto.Price;
            delivery.PickPoint = deliveryDto.PickPointId;
            delivery.UpPoint = deliveryDto.UpPointId;
            delivery.SenderId = deliveryDto.SenderId;
            delivery.RecipientId = deliveryDto.RecipientId;
        }

        public static IEnumerable<DeliveryDTO> MapAll(IEnumerable<Delivery> deliveries)
        {
            return deliveries.ToList().ConvertAll(Map);
        }
    }
}
