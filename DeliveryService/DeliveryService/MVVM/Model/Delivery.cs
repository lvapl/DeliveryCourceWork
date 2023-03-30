using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class Delivery
{
    public int Id { get; set; }

    public int? TariffId { get; set; }

    public decimal? Price { get; set; }

    public int? SenderId { get; set; }

    public int? RecipientId { get; set; }

    public int? PickPoint { get; set; }

    public int? UpPoint { get; set; }

    public virtual ICollection<DeliveryHistory> DeliveryHistories { get; } = new List<DeliveryHistory>();

    public virtual PickUpPoint? PickPointNavigation { get; set; }

    public virtual User? Recipient { get; set; }

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual User? Sender { get; set; }

    public virtual Tariff? Tariff { get; set; }
}
