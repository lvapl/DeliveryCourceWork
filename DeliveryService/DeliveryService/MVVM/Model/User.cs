using System;
using System.Collections.Generic;

namespace DeliveryService.MVVM.Model;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? AddressId { get; set; }

    public int PassportNumber { get; set; }

    public int PassportSeries { get; set; }

    public int? PassportAddress { get; set; }

    public string TelephoneNumber { get; set; } = null!;

    public virtual Address? Address { get; set; }

    public virtual ICollection<Delivery> DeliveryRecipients { get; } = new List<Delivery>();

    public virtual ICollection<Delivery> DeliverySenders { get; } = new List<Delivery>();

    public virtual Address? PassportAddressNavigation { get; set; }

    public virtual Worker? Worker { get; set; }
}
