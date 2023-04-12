using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class WorkersInStorage
{
    public int WorkerId { get; set; }

    public int StorageId { get; set; }

    public int WorkingShift { get; set; }

    public virtual Storage Storage { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;

    public virtual Shift WorkingShiftNavigation { get; set; } = null!;
}
