using System;
using System.Collections.Generic;

namespace Project6.Models;

public partial class Member
{
    public Guid MemberId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string HashPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Roles { get; set; } = null!;

    public int EmployeeId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Memberaddress> Memberaddresses { get; set; } = new List<Memberaddress>();

    public virtual ICollection<RegularizationRequest> RegularizationRequests { get; set; } = new List<RegularizationRequest>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Sessionlog> Sessionlogs { get; set; } = new List<Sessionlog>();
}
