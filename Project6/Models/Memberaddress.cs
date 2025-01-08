using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Memberaddress
{
    public Guid MemberAddressId { get; set; }

    public string AddressType { get; set; } = null!;

    public Guid MemberId { get; set; }

    public Guid AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
