using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class DeliveryHistory
{
    public int Id { get; set; }

    public int? DeliveryId { get; set; }

    public string? DeliveryStatus { get; set; }

    public DateTime DateTime { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
