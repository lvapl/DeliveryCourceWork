using System;

namespace DeliveryService.DTO
{
    /// <summary>
    /// Объект служащий для отображения и изменения необходимых данных.
    /// </summary>
    public class WorkersInPickUpPointsDTO
    {
        public int Id { get; set; }

        public int WorkerId { get; set; }

        public int WorkerIdOriginal { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!; 

        public string? Patronymic { get; set; }

        public int PickUpPointId { get; set; }

        public int PickUpPointIdOriginal { get; set; }

        public AddressDTO? Address { get; set; }
        
        public int ShiftId { get; set; }

        public int ShiftIdOriginal { get; set; }
        
        public TimeSpan StartedShiftAt { get; set; }
        
        public TimeSpan EndedShiftAt { get; set; }
    }
}