using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class ViewGetInformationDelivery
{
    public int DeliveryNumber { get; set; }

    public string SenderFirstname { get; set; } = null!;

    public string SenderLastname { get; set; } = null!;

    public string? SenderPatronymic { get; set; }

    public string RecipientFirstname { get; set; } = null!;

    public string RecipientLastname { get; set; } = null!;

    public string? RecipientPatronymic { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public DateTime? DateTime { get; set; }
}
