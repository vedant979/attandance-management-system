using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Report
{
    public Guid ReportId { get; set; }

    public Guid MemberId { get; set; }

    public DateOnly ReportMonth { get; set; }

    public int? TotalPresent { get; set; }

    public int? TotalAbsent { get; set; }

    public int? TotalLate { get; set; }

    public int? TotalOnLeave { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public virtual Member Member { get; set; } = null!;
}
