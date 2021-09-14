using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public class PatientManager : IDisposable
    {
        private UnitOfWork unitOfWork;

        public PatientManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public IQueryable<Patient> GetAll()
        {
            return unitOfWork.PatientRepository.Get(orderBy: q => q.OrderBy(d => d.Name)).AsQueryable();
        }

        public Patient Find(int? id)
        {
            return unitOfWork.PatientRepository.GetByID(id);
        }

        public void Insert(Patient patient)
        {
            unitOfWork.PatientRepository.Insert(patient);
            unitOfWork.Save();
        }

        public void Update(Patient patient)
        {
            unitOfWork.PatientRepository.Update(patient);
            unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            Patient patient = unitOfWork.PatientRepository.GetByID(id);
            unitOfWork.PatientRepository.Delete(patient);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
