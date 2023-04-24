using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class WorkersInPickUpPointsMapper
    {
        public static WorkersInPickUpPointsDTO Map(WorkersInPickUpPoint workersInPickUpPoint)
        {
            return new WorkersInPickUpPointsDTO
            {
                WorkerId = workersInPickUpPoint.WorkerId,
                FirstName = workersInPickUpPoint.Worker.IdNavigation.Firstname,
                LastName = workersInPickUpPoint.Worker.IdNavigation.Lastname,
                Patronymic = workersInPickUpPoint.Worker.IdNavigation.Patronymic,
                PickUpPointId = workersInPickUpPoint.PickUpPointId,
                Address = workersInPickUpPoint.PickUpPoint.Address == null ? null : AddressMapper.Map(workersInPickUpPoint.PickUpPoint.Address),
                ShiftId = workersInPickUpPoint.WorkingShift,
                StartedShiftAt = workersInPickUpPoint.WorkingShiftNavigation.StartedShiftAt,
                EndedShiftAt = workersInPickUpPoint.WorkingShiftNavigation.EndedShiftAt
            };
        }

        public static void Map(WorkersInPickUpPointsDTO workersInPickUpPointsDTO, WorkersInPickUpPoint workersInPickUpPoint)
        {
            workersInPickUpPoint.WorkerId = workersInPickUpPointsDTO.WorkerId;
            workersInPickUpPoint.PickUpPointId = workersInPickUpPointsDTO.PickUpPointId;
            workersInPickUpPoint.WorkingShift = workersInPickUpPointsDTO.ShiftId;
        }

        public static IEnumerable<WorkersInPickUpPointsDTO> MapAll(IEnumerable<WorkersInPickUpPoint> workersInPickUpPoints)
        {
            return workersInPickUpPoints.ToList().ConvertAll(Map);
        }
    }
}
