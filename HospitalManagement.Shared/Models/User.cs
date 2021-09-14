using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Shared.Models
{
    public enum UserTypes
    {
        Admin = 0,
        Doctor = 1,
        Nurse = 2,
        Patient = 3
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Ssn { get; set; }
        public UserTypes UserType { get; set; }
    }
}
