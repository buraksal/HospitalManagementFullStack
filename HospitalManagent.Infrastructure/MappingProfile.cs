using AutoMapper;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagent.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
