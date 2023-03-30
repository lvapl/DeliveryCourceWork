using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Storage
{
    public int Id { get; set; }

    public int? AddressId { get; set; }

    public string? Title { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<WorkersInStorage> WorkersInStorages { get; } = new List<WorkersInStorage>();
}
