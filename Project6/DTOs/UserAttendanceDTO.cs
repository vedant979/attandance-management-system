using Project6.Models;

namespace Project6.DTOs
{
    public class UserAttendanceDto
    {
        // Attendance-related properties
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly AttendanceDate { get; set; }
        public string? Status { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }

    }
}
