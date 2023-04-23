using System;

namespace DeliveryService.DTO
{
    public class WorkersInPickUpPointsDTO
    {
        public int WorkerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Patronymic { get; set; }

        public int PickUpPointId { get; set; }

        public AddressDTO? Address { get; set; }
        
        public int ShiftId { get; set; }
        
        public TimeSpan StartedShiftAt { get; set; }
        
        public TimeSpan EndedShiftAt { get; set; }
    }
}