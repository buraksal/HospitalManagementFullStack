using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Shared.Models;
using HospitalManagent.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagement.Business
{
    public class PatientService : IPatientService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IContainer container;

        public PatientService(IUnitOfWork unitOfWork, IContainer container)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
        }

        public IQueryable<Patient> GetAll()
        {
            return this.container.Repository<Patient>().Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public Patient Find(string ssn)
        {
            var patient = this.container.Repository<Patient>().Get(p => p.Ssn.Equals(ssn));
            return patient.ToList()[0];
        }

        public void Insert(Patient patient)
        {
            this.container.Repository<Patient>().Insert(patient);
            unitOfWork.Save();
        }

        public void Update(Patient patient)
        {
            this.container.Repository<Patient>().Update(patient);
            unitOfWork.Save();
        }

        public void Delete(Patient patient)
        {
            this.container.Repository<Patient>().Delete(patient);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
