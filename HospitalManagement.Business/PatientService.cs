using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public class PatientService : IPatientService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Patient> GetAll()
        {
            return unitOfWork.Patients.Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public Patient Find(int? id)
        {
           return unitOfWork.Patients.GetByID(id);
        }

        public void Insert(Patient patient)
        {
            unitOfWork.Patients.Insert(patient);
            unitOfWork.Save();
        }

        public void Update(Patient patient)
        {
            unitOfWork.Patients.Update(patient);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            Patient patient = unitOfWork.Patients.GetByID(id);
            unitOfWork.Patients.Delete(patient);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
