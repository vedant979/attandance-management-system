using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project6.Models;

public partial class Attendance
{
    public Guid AttendanceId { get; set; }

    public Guid MemberId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime LogoutTime { get; set; }

    public DateTime LoginTime { get; set; }


    [JsonIgnore]
    public virtual Member Member { get; set; } = null!;
}
