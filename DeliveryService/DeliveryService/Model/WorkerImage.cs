using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class WorkerImage
{
    public int Id { get; set; }

    public byte[] WorkerImage1 { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
