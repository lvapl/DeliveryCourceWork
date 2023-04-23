using System.Collections.Generic;
using System.Linq;
using DeliveryService.DTO;
using DeliveryService.Model;

namespace DeliveryService.Mappers
{
    public static class PickUpPointMapper
    {
        public static PickUpPointDTO Map(PickUpPoint pickUpPoint)
        {
            return new PickUpPointDTO
            {
                Id = pickUpPoint.Id,
                Address = pickUpPoint.Address == null ? null : AddressMapper.Map(pickUpPoint.Address)
            };
        }

        public static void Map(PickUpPointDTO pickUpPointDto, PickUpPoint pickUpPoint)
        {
            if (pickUpPointDto.Address != null)
            {
                AddressMapper.Map(pickUpPointDto.Address, pickUpPoint.Address ?? (pickUpPoint.Address = new Address()));
            }
        }

        public static IEnumerable<PickUpPointDTO> MapAll(IEnumerable<PickUpPoint> pickUpPoints)
        {
            return pickUpPoints.ToList().ConvertAll(Map);
        }
    }
}
