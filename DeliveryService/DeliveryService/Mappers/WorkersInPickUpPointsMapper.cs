using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    /// <summary>
    /// Класс для преобразования модели <see cref="WorkersInPickUpPoint"/> в <see cref="WorkersInPickUpPointsDTO"/> и обратно.
    /// </summary>
    public class WorkersInPickUpPointsMapper
    {
        /// <summary>
        /// Метод для преобразования <see cref="WorkersInPickUpPoint"/> в <see cref="WorkersInPickUpPointsDTO"/>.
        /// </summary>
        /// <param name="workersInPickUpPoint">Модель <see cref="WorkersInPickUpPoint"/> по которой нужно выполнить преобразование.</param>
        /// <returns>DTO объект <see cref="WorkersInPickUpPointsDTO"/>, полученный в результате преобразования.</returns>
        public static WorkersInPickUpPointsDTO Map(WorkersInPickUpPoint workersInPickUpPoint)
        {
            return new WorkersInPickUpPointsDTO
            {
                Id = workersInPickUpPoint.Id,
                WorkerId = workersInPickUpPoint.WorkerId,
                WorkerIdOriginal = workersInPickUpPoint.WorkerId,
                FirstName = workersInPickUpPoint.Worker.IdNavigation.Firstname,
                LastName = workersInPickUpPoint.Worker.IdNavigation.Lastname,
                Patronymic = workersInPickUpPoint.Worker.IdNavigation.Patronymic,
                PickUpPointId = workersInPickUpPoint.PickUpPointId,
                PickUpPointIdOriginal = workersInPickUpPoint.PickUpPointId,
                Address = workersInPickUpPoint.PickUpPoint.Address == null ? null : AddressMapper.Map(workersInPickUpPoint.PickUpPoint.Address),
                ShiftId = workersInPickUpPoint.WorkingShift,
                ShiftIdOriginal = workersInPickUpPoint.WorkingShift,
                StartedShiftAt = workersInPickUpPoint.WorkingShiftNavigation.StartedShiftAt,
                EndedShiftAt = workersInPickUpPoint.WorkingShiftNavigation.EndedShiftAt
            };
        }

        /// <summary>
        /// Метод для преобразования объекта <see cref="WorkersInPickUpPointsDTO"/> в <see cref="WorkersInPickUpPoint"/>.
        /// </summary>
        /// <param name="workersInPickUpPointsDTO">DTO объект <see cref="WorkersInPickUpPointsDTO"/> по которому нужно выполнить преобразование.</param>
        /// <param name="workersInPickUpPoint">Модель <see cref="WorkersInPickUpPoint"/>, полученная в результате преобразования.</param>
        public static void Map(WorkersInPickUpPointsDTO workersInPickUpPointsDTO, WorkersInPickUpPoint workersInPickUpPoint)
        {
            workersInPickUpPoint.WorkerId = workersInPickUpPointsDTO.WorkerId;
            workersInPickUpPoint.PickUpPointId = workersInPickUpPointsDTO.PickUpPointId;
            workersInPickUpPoint.WorkingShift = workersInPickUpPointsDTO.ShiftId;
        }

        /// <summary>
        /// Метод для преобразования коллекции <see cref="WorkersInPickUpPoint"/> в коллекцию <see cref="WorkersInPickUpPointsDTO"/>.
        /// </summary>
        /// <param name="workers">Коллекция <see cref="WorkersInPickUpPoint"/>, которую нужно отобразить.</param>
        /// <returns>Коллекция <see cref="WorkersInPickUpPointsDTO"/>, полученная в результате преобразования.</returns>
        public static IEnumerable<WorkersInPickUpPointsDTO> MapAll(IEnumerable<WorkersInPickUpPoint> workersInPickUpPoints)
        {
            return workersInPickUpPoints.ToList().ConvertAll(Map);
        }
    }
}
