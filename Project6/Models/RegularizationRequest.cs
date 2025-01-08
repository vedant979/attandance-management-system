using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class RegularizationRequest
{
    public Guid RequestId { get; set; }

    public Guid MemberId { get; set; }

    public DateOnly RequestedDate { get; set; }

    public string? RegularizationReason { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid AttendanceId { get; set; }

    public virtual Member Member { get; set; } = null!;
}
