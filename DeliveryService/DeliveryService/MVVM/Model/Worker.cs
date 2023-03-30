using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Worker
{
    public int Id { get; set; }

    public int PositionId { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<WorkersInPickUpPoint> WorkersInPickUpPoints { get; } = new List<WorkersInPickUpPoint>();

    public virtual ICollection<WorkersInStorage> WorkersInStorages { get; } = new List<WorkersInStorage>();

    public virtual ICollection<DeliveryHistory> DeliveryHistories { get; } = new List<DeliveryHistory>();
}
