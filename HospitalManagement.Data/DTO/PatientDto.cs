using HospitalManagement.Service.DTO.Interfaces;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO
{
    public class PatientDto: IPatientDto
    {
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Complaint { get; set; }
        public string CreatedBy { get; set; }
    }
}
