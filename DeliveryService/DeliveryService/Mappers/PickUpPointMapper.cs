using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    /// <summary>
    /// Класс для преобразования модели <see cref="PickUpPoint"/> в <see cref="PickUpPointDTO"/> и обратно.
    /// </summary>
    public static class PickUpPointMapper
    {
        /// <summary>
        /// Метод для преобразования <see cref="PickUpPoint"/> в <see cref="PickUpPointDTO"/>.
        /// </summary>
        /// <param name="pickUpPoint">Модель <see cref="PickUpPoint"/> по которой нужно выполнить преобразование.</param>
        /// <returns>DTO объект <see cref="PickUpPointDTO"/>, полученный в результате преобразования.</returns>
        public static PickUpPointDTO Map(PickUpPoint pickUpPoint)
        {
            return new PickUpPointDTO
            {
                Id = pickUpPoint.Id,
                Address = pickUpPoint.Address == null ? null : AddressMapper.Map(pickUpPoint.Address)
            };
        }

        /// <summary>
        /// Метод для преобразования объекта <see cref="PickUpPointDTO"/> в <see cref="PickUpPoint"/>.
        /// </summary>
        /// <param name="pickUpPointDto">DTO объект <see cref="PickUpPointDTO"/> по которому нужно выполнить преобразование.</param>
        /// <param name="pickUpPoint">Модель <see cref="PickUpPoint"/>, полученная в результате преобразования.</param>
        public static void Map(PickUpPointDTO pickUpPointDto, PickUpPoint pickUpPoint)
        {
            if (pickUpPointDto.Address != null)
            {
                AddressMapper.Map(pickUpPointDto.Address, pickUpPoint.Address ?? (pickUpPoint.Address = new Address()));
            }
        }

        /// <summary>
        /// Метод для преобразования коллекции <see cref="PickUpPoint"/> в коллекцию <see cref="PickUpPointDTO"/>.
        /// </summary>
        /// <param name="pickUpPoints">Коллекция <see cref="PickUpPoint"/>, которую нужно отобразить.</param>
        /// <returns>Коллекция <see cref="PickUpPointDTO"/>, полученная в результате преобразования.</returns>
        public static IEnumerable<PickUpPointDTO> MapAll(IEnumerable<PickUpPoint> pickUpPoints)
        {
            return pickUpPoints.ToList().ConvertAll(Map);
        }
    }
}
