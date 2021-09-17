using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO
{
    public interface ILoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
