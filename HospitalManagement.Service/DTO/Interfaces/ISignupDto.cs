using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO.Interfaces
{
    interface ISignupDto
    {
        public UserTypes UserType { get; set; }
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
