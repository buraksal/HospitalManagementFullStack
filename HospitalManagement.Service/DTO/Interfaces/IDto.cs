using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO
{
    public enum UserTypes
    {
        Admin = 0,
        Doctor = 1,
        Nurse = 2,
        Patient = 3
    }
    public interface IDto
    {
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
