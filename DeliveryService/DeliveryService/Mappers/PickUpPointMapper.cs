using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class PickUpPointMapper
    {
        public static PickUpPointDTO Map(PickUpPoint pickUpPoint)
        {
            return new PickUpPointDTO
            {
                Id = pickUpPoint.Id,
                Address = pickUpPoint.Address == null ? null : AddressMapper.Map(pickUpPoint.Address)
            };
        }

        public static void Map(PickUpPointDTO pickUpPointDTO, PickUpPoint pickUpPoint)
        {
            if (pickUpPointDTO.Address != null)
            {
                AddressMapper.Map(pickUpPointDTO.Address, pickUpPoint.Address ?? (pickUpPoint.Address = new Address()));
            }
        }

        public static IEnumerable<PickUpPointDTO> MapAll(IEnumerable<PickUpPoint> pickUpPoints)
        {
            return pickUpPoints.ToList().ConvertAll<PickUpPointDTO>(x => Map(x));
        }
    }
}
