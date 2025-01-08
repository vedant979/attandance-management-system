using Microsoft.AspNetCore.Mvc;
using Moq;
using Project6.Controllers;
using Project6.DTOs;
using Project6.DTOs.Project5.DTOs;
using Project6.Models;
using Project6.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6.Tests.ControllerTests
{
    public class AdminControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new AdminController(_mockUserService.Object);
        }

        #region RegisterUserAsync Tests

        [Fact]
        public async Task RegisterUserAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            RegisterUserDTO validUser = new RegisterUserDTO()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "SecurePassw0rd123"
            };

            var res = _mockUserService
           .Setup(service => service.RegisterUserAsync(It.IsAny<RegisterUserDTO>()))
           .ReturnsAsync(true);
            var result = await _controller.RegisterUserAsync(validUser);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task RegisterUserAsync_ReturnsBadRequest_WhenRegistrationFails()
        {

            var userDto = new RegisterUserDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.do123e@example.com",
                Password = "SecurePassw0rd123"
            };
            _mockUserService.Setup(service => service.RegisterUserAsync(It.IsAny<RegisterUserDTO>()))
                .ReturnsAsync(false);

            // Act: Call the method under test
            var result = await _controller.RegisterUserAsync(userDto);

            // Assert: Verify the result type
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Registration failed!", badRequestResult.Value);
        }
        [Fact]
        public async Task RegisterUserAsync_ReturnsBadRequest_WhenExceptionOccurs()
        {

            var userDto = new RegisterUserDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.do123e@example.com",
                Password = "SecurePassw0rd123"
            };
            _mockUserService.Setup(service => service.RegisterUserAsync(It.IsAny<RegisterUserDTO>()))
                .ThrowsAsync(new Exception("Some error occurred"));

            // Act: Call the method under test
            var result = await _controller.RegisterUserAsync(userDto);

            // Assert: Verify the result type
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Registration failed!", badRequestResult.Value);
        }

        #endregion

        #region GetAllUser Tests

        [Fact]
        public async Task GetAllUser_ReturnsOk_WhenUsersExist()
        {

            var users = new List<AllUserResponseDTO>();
            _mockUserService.Setup(service => service.GetAllUserData()).ReturnsAsync(users);

            // Act
            var result = await _controller.getAllUser();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<List<AllUserResponseDTO>>(okResult.Value);
            Assert.NotEmpty(response);
        }

        [Fact]
        public async Task GetAllUser_ReturnsBadRequest_WhenNoUsersFound()
        {

            var users = new List<AllUserResponseDTO>();
            _mockUserService.Setup(service => service.GetAllUserData()).ReturnsAsync(users);

            // Act
            var result = await _controller.getAllUser();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(badRequestResult.Value);
            Assert.Equal("No users found", response.Message);
        }

        #endregion

        #region GetUsersAttendance Tests

        [Fact]
        public async Task GetUsersAttendance_ReturnsOk_WhenDataExists()
        {
            // Arrange
            var attendanceData = new List<UserAttendanceDto> { /* Initialize with some attendance data */ };
            _mockUserService.Setup(service => service.GetUsersAttendance(It.IsAny<int>())).ReturnsAsync(attendanceData);

            // Act
            var result = await _controller.getUsersAttendance(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<List<UserAttendanceDto>>(okResult.Value);
            Assert.NotEmpty(response);
        }

        [Fact]
        public async Task GetUsersAttendance_ReturnsBadRequest_WhenNoDataFound()
        {
            // Arrange
            _mockUserService.Setup(service => service.GetUsersAttendance(It.IsAny<int>())).ReturnsAsync(new List<UserAttendanceDto>());

            // Act
            var result = await _controller.getUsersAttendance(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(badRequestResult.Value);
            Assert.Equal("No data found", response.Message);
        }

        #endregion

        #region GetUserAttendanceReport Tests

        [Fact]
        public async Task GetUserAttendanceReport_ReturnsOk_WhenDataExists()
        {
            // Arrange
            var attendanceData = new List<UserAttendanceDto> { /* Initialize with some attendance data */ };
            _mockUserService.Setup(service => service.GetUsersAttendance(It.IsAny<int>())).ReturnsAsync(attendanceData);

            // Act
            var result = await _controller.GetUserAttendanceReport(1, 12);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<List<UserAttendanceDto>>(okResult.Value);
            Assert.NotEmpty(response);
        }

        [Fact]
        public async Task GetUserAttendanceReport_ReturnsBadRequest_WhenNoDataFound()
        {
            // Arrange
            _mockUserService.Setup(service => service.GetUsersAttendance(It.IsAny<int>())).ReturnsAsync(new List<UserAttendanceDto>());

            // Act
            var result = await _controller.GetUserAttendanceReport(1, 12);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(badRequestResult.Value);
            Assert.Equal("No data found", response.Message);
        }

        #endregion

        #region PostRegularizeRequest Tests

        [Fact]
        public async Task PostRegularizeRequest_ReturnsOk_WhenRequestAdded()
        {
            // Arrange
            var regularizationRequest = new RegularizationRequestDTO { /* Initialize with valid data */ };
            _mockUserService.Setup(service => service.PostRegularizeRequest(It.IsAny<int>(), regularizationRequest)).ReturnsAsync(true);

            // Act
            var result = await _controller.PostRegularizeRequest(1, regularizationRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.Equal("Request added", response.Message);
        }

        [Fact]
        public async Task PostRegularizeRequest_ReturnsBadRequest_WhenRequestFailed()
        {
            // Arrange
            var regularizationRequest = new RegularizationRequestDTO { /* Initialize with valid data */ };
            _mockUserService.Setup(service => service.PostRegularizeRequest(It.IsAny<int>(), regularizationRequest)).ReturnsAsync(false);

            // Act
            var result = await _controller.PostRegularizeRequest(1, regularizationRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(badRequestResult.Value);
            Assert.Equal("Please try again later", response.Message);
        }

        #endregion

        #region UpdateRequestStatus Tests

        [Fact]
        public async Task UpdateRequestStatus_ReturnsOk_WhenStatusUpdated()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            _mockUserService.Setup(service => service.UpdateRequestStatus(It.IsAny<int>(), requestId, It.IsAny<bool>())).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateRequestStatus(1, requestId, true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.Equal("Status updated", response.Message);
        }

        [Fact]
        public async Task UpdateRequestStatus_ReturnsBadRequest_WhenFailed()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            _mockUserService.Setup(service => service.UpdateRequestStatus(It.IsAny<int>(), requestId, It.IsAny<bool>())).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateRequestStatus(1, requestId, true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(badRequestResult.Value);
            Assert.Equal("Please try again later", response.Message);
        }

        #endregion
    }
}
