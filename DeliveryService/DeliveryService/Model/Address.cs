using System;
using System.Collections.Generic;

namespace DeliveryService.Model;

public partial class Address
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? StreetId { get; set; }

    public int? HouseId { get; set; }

    public int Postcode { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<DeliveryHistory> DeliveryHistories { get; } = new List<DeliveryHistory>();

    public virtual House? House { get; set; }

    public virtual ICollection<PickUpPoint> PickUpPoints { get; } = new List<PickUpPoint>();

    public virtual ICollection<Storage> Storages { get; } = new List<Storage>();

    public virtual Street? Street { get; set; }

    public virtual ICollection<User> UserAddresses { get; } = new List<User>();

    public virtual ICollection<User> UserPassportAddressNavigations { get; } = new List<User>();
}
