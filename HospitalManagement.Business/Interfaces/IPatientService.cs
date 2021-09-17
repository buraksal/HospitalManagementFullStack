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
        Patient Find(string ssn);
        void Insert(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        void Dispose();
    }
}
