using Project6.Models;
using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    using System;
    using System.Collections.Generic;

    namespace Project5.DTOs
    {
        public class AddressDTO
        {
            public string? HouseNo { get; set; }
            public string? Street { get; set; }
            public string? PinCode { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? Country { get; set; }
            public string? AddressType { get; set; }
        }

        public class ContactDTO
        {
            public int? PhoneNumber { get; set; }
            public string? ContactType { get; set; }
        }

        public class AllUserResponseDTO
        {
            public List<UserResponseDTO> Users { get; set; }
        }
        public class UserResponseDTO
        {
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? Gender { get; set; }
            public string? Email { get; set; }
            public List<AddressDTO>? Addresses { get; set; }
            public List<ContactDTO>? Contacts { get; set; }
        }
    }

}
