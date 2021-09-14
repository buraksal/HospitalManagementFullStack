using HospitalManagement.Service.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO
{
    public class LoginDto: ILoginDto
    {
        public UserTypes UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
