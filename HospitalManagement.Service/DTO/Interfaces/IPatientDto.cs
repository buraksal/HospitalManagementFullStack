using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO.Interfaces
{
    interface IPatientDto: IDto
    {
        public string Complaint { get; set; }
        public User CreatedBy { get; set; }
    }
}
