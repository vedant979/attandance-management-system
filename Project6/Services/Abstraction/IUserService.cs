using Project6.Data.Repository.Abstraction;
using Project6.DTOs;
using Project6.DTOs.Project5.DTOs;
using Project6.Models;

namespace Project6.Services.Abstraction
{
    public interface IUserService
    {
        Task<bool> UpdateRequestStatus(int empId,Guid requestId, bool isApproved);
        Task<bool> PostRegularizeRequest(int? empId, RegularizationRequestDTO requestDTO);
        Task<List<UserAttendanceDto>?> GetUserReport(int? employeeId, int month);
        Task<List<UserAttendanceDto>?> GetUsersAttendance(int? id);
        Task<List<AllUserResponseDTO>> GetAllUserData();
        Task<bool> AttendancePunchIn();
        Task<bool> AttendancePunchOut();
        Task<bool> UpdateContactAsync(UpdateContactDTO updateContact);
        Task<bool> AddContactAsync(AddContactDTO updateContact);
        Task<bool> RegisterUserAsync(RegisterUserDTO registerUser);
        Task<string> LoginUserAsync(LoginUserDTO loginUserDto);
        Task<List<UserResponseDTO>> GetUserData();
        Task<bool> IsUserSessionValid(Guid userId);
        Task<Member> updateUserDetailsAsync(UpdateMemberDTO updateMember);
        Task<Address> updateAddressDetailsAsync(Guid id, UpdateAddressDTO updateAddress);
        Task<Address> addAddressDetailsAsync(DTOs.AddressDTO addAddress);
        Task<bool> RecoverPasswordAsync(RecoverPasswordDTO recoverPassword);
        Task<bool> ResetPasswordAsync(ChangeUserCredentialDTO changeUserCredential);
        Task<bool> LogoutAsync();
        Task<bool> CheckUserSessionAsync(Guid id);
    }
}
