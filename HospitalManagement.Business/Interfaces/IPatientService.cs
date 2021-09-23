using HospitalManagement.Data.DTO;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business.Interfaces
{
    public interface IPatientService
    {
        IQueryable<Patient> GetAll();
        IQueryable<Patient> GetWithPagination(PaginationDto request);
        Patient Find(string ssn);
        void Insert(PatientDto request);
        void Update(PatientDto request);
        void Delete(PatientDto request);
        void Dispose();
        Patient CreatePatient(PatientDto request);
        void Test2();
    }
}
