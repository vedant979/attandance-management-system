using Project6.Data.Repository.Implementation;
using Project6.DTOs;
using Project6.Models;

namespace Project6.Data.Repository.Abstraction
{
    public interface IUserRepository
    {
        Task<bool> UpdateRequestStatus(int empId, Guid requestId, bool isApproved);
        Task<bool> PostRegularizeRequest(int? empId,RegularizationRequest request);
        Task<Member> GetUserRole(Guid userId);
        Task<bool> RegisterUserAsync(Member member);
        Task<bool> UpdateMember(Guid id, Member member);
        Task<bool> CheckUserInDb(string email);
        Task<bool> UpdateAddress(Guid id, Address address, Memberaddress memberAddress);
        Task<Member> GetUserByEmail(string email);
        Task<bool> AddAddress(Guid id, Address address, Memberaddress memberAddress);
        Task<bool> UpdatePassword(Guid id, string password);
        Task<bool> CheckUserSession(Guid memberId);
        Task<List<Member>> GetUserData();
        Task<bool> InvalidateToken(Guid id);
        Task<bool> AddContact(Contact contact);
        Task<bool> UpdateContact(Contact contact, int? phoneNumber);
        Task<bool> CheckUserWithContact(int? phoneNumber);
        Task<bool> AddUserSession(Guid memberId,string Token);
        Task<bool> AttendancePunchIn(Guid memberId, Attendance attendance);
        Task<bool> AttendancePunchOut(Guid memberId, Attendance attendance);
        Task<List<Member>> GetAllUserDetails();
        Task<List<Attendance>> GetUsersAttendance(int? employeeId);
        Task<List<Attendance>> GetUserReport(int? employeeId, int month);
    }
}
