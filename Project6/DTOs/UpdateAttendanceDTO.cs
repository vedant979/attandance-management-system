namespace Project6.DTOs
{
    public class UpdateAttendanceDTO
    {
            public int AttendanceId { get; set; }

            public int UserId { get; set; }

            public DateTime? AttendanceDate { get; set; }

            public string Status { get; set; } = string.Empty;

            public string? Remarks { get; set; }

     }
}
