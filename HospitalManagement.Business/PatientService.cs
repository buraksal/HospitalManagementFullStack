using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
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

        public void Insert(PatientDto request)
        {
            Patient patient = CreatePatient(request);
            this.container.Repository<Patient>().Insert(patient);
            unitOfWork.Save();
        }

        public void Update(PatientDto request)
        {
            Patient patient = this.Find(request.Ssn);
            if(patient == null || patient.Ssn != request.Ssn)
            {
                return;
            }
            Patient updateTo = new Patient
            {
                Id = patient.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Complaint = request.Complaint,
                Ssn = patient.Ssn,
                CreatedBy = request.CreatedBy
            };
            this.container.Repository<Patient>().Update(updateTo);
            unitOfWork.Save();
        }

        public void Delete(PatientDto request)
        {
            Patient patient = this.Find(request.Ssn);
            this.container.Repository<Patient>().Delete(patient);
            //relation service çağır
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        private Patient CreatePatient(PatientDto request)
        {
            Patient patient = new Patient
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Complaint = request.Complaint,
                Ssn = request.Ssn,
                CreatedBy = request.CreatedBy
            };
            return patient;
        }

    }
}
