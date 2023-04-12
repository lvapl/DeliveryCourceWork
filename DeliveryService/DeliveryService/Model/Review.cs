using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class Review
{
    public int Id { get; set; }

    public int Grade { get; set; }

    public string? ReviewDescription { get; set; }

    public int? DeliveryId { get; set; }

    public virtual Delivery? Delivery { get; set; }
}
