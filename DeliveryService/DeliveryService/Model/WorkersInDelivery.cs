using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class WorkersInDelivery
{
    public int WorkerId { get; set; }

    public int DeliveryHistoryId { get; set; }

    public int Id { get; set; }

    public virtual DeliveryHistory DeliveryHistory { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;
}
