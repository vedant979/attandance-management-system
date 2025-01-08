using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Sessionlog
{
    public Guid SessionlogId { get; set; }

    public string Token { get; set; } = null!;

    public Guid MemberId { get; set; }

    public string IsValid { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
