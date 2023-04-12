using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class ViewGetWorkersInDelivery
{
    public int DeliveryNumber { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? DeliveryStatus { get; set; }

    public DateTime DateTime { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;
}
