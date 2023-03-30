using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class WorkersInPickUpPoint
{
    public int WorkerId { get; set; }

    public int PickUpPointId { get; set; }

    public int WorkingShift { get; set; }

    public virtual PickUpPoint PickUpPoint { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;

    public virtual Shift WorkingShiftNavigation { get; set; } = null!;
}
