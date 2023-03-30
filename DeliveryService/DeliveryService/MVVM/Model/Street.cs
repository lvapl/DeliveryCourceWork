using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Street
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();
}
