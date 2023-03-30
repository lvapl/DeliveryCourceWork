using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Shift
{
    public int Id { get; set; }

    public TimeSpan StartedShiftAt { get; set; }

    public TimeSpan EndedShiftAt { get; set; }

    public virtual ICollection<WorkersInPickUpPoint> WorkersInPickUpPoints { get; } = new List<WorkersInPickUpPoint>();

    public virtual ICollection<WorkersInStorage> WorkersInStorages { get; } = new List<WorkersInStorage>();
}
