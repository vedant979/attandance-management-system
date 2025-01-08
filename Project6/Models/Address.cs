using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Address
{
    public Guid AddressId { get; set; }

    public string? HouseNo { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Memberaddress> Memberaddresses { get; set; } = new List<Memberaddress>();
}
