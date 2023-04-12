using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class House
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();
}
