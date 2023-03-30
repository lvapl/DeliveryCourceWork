using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
