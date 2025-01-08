using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Contact
{
    public Guid ContactId { get; set; }

    public int? PhoneNumber { get; set; }

    public Guid MemberId { get; set; }

    public string? ContactType { get; set; }

    public virtual Member Member { get; set; } = null!;
}
