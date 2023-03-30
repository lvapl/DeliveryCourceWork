using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Tariff
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();
}
