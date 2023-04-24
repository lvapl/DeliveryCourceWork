using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    /// <summary>
    /// Класс для преобразования модели <see cref="Delivery"/> в <see cref="DeliveryDTO"/> и обратно.
    /// </summary>
    public static class DeliveryMapper
    {
        /// <summary>
        /// Метод для преобразования <see cref="Delivery"/> в <see cref="DeliveryDTO"/>.
        /// </summary>
        /// <param name="delivery">Модель <see cref="Delivery"/> по которой нужно выполнить преобразование.</param>
        /// <returns>DTO объект <see cref="DeliveryDTO"/>, полученный в результате преобразования.</returns>
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

        /// <summary>
        /// Метод для преобразования объекта <see cref="DeliveryDTO"/> в <see cref="Delivery"/>.
        /// </summary>
        /// <param name="deliveryDto">DTO объект <see cref="DeliveryDTO"/> по которому нужно выполнить преобразование.</param>
        /// <param name="delivery">Модель <see cref="Delivery"/>, полученная в результате преобразования.</param>
        public static void Map(DeliveryDTO deliveryDto, Delivery delivery)
        {
            delivery.TariffId = deliveryDto.TariffId;
            delivery.Price = deliveryDto.Price;
            delivery.PickPoint = deliveryDto.PickPointId;
            delivery.UpPoint = deliveryDto.UpPointId;
            delivery.SenderId = deliveryDto.SenderId;
            delivery.RecipientId = deliveryDto.RecipientId;
        }

        /// <summary>
        /// Метод для преобразования коллекции <see cref="Delivery"/> в коллекцию <see cref="DeliveryDTO"/>.
        /// </summary>
        /// <param name="deliveries">Коллекция <see cref="Delivery"/>, которую нужно отобразить.</param>
        /// <returns>Коллекция <see cref="DeliveryDTO"/>, полученная в результате преобразования.</returns>
        public static IEnumerable<DeliveryDTO> MapAll(IEnumerable<Delivery> deliveries)
        {
            return deliveries.ToList().ConvertAll(Map);
        }
    }
}
