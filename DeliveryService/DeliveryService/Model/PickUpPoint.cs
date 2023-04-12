using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class PickUpPoint
{
    public int Id { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();

    public virtual ICollection<WorkersInPickUpPoint> WorkersInPickUpPoints { get; } = new List<WorkersInPickUpPoint>();
}
