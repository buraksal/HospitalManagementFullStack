using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.DTO.Interfaces
{
    public interface IPatientDto: IDto
    {
        public string Complaint { get; set; }
        public string CreatedBy { get; set; }
    }
}
