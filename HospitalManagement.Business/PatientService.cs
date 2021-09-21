using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using HospitalManagent.Infrastructure;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Business
{
    public class PatientService : IPatientService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IContainer container;

        private readonly IUserService userService;

        private readonly IRelationService relationService;

        public PatientService(IUnitOfWork unitOfWork, IContainer container, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
            this.userService = userService;
        }

        public IQueryable<Patient> GetAll()
        {
            var pageNumber = 1;
            var patients = this.container.Repository<Patient>().Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
            var onePagePatients = patients.ToPagedList(pageNumber, 2);
            return (IQueryable<Patient>)onePagePatients;
        }

        public Patient Find(string ssn)
        {
            //TODO include implementation after 1-1, 1-* 
            Patient patient = this.container.Repository<Patient>().Get(p => p.Ssn.Equals(ssn)).FirstOrDefault();
            return patient;
        }

        public void Insert(PatientDto request)
        {
            Patient toCompare = this.container.Repository<Patient>().Get(p => p.Ssn.Equals(request.Ssn) 
                                    && p.Complaint.Equals(request.Complaint)).FirstOrDefault(); 
            if(toCompare == null)
            {
                Patient patient = CreatePatient(request);
                this.container.Repository<Patient>().Insert(patient);
                this.relationService.Insert(request);
                unitOfWork.Save();
            }
            
        }

        public void Update(PatientDto request)
        {
            Patient patient = this.Find(request.Ssn);
            if(patient == null || patient.Ssn != request.Ssn)
            {
                return;
            }
            User user = this.userService.Find(request.CreatedBy);
            Patient updateTo = new Patient
            {
                Id = patient.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Complaint = request.Complaint,
                Ssn = patient.Ssn,
                CreatedBy = user
            };
            this.container.Repository<Patient>().Update(updateTo);
            unitOfWork.Save();
        }

        public void Delete(PatientDto request)
        {
            Patient patient = this.Find(request.Ssn);
            this.container.Repository<Patient>().Delete(patient);
            List<UserPatientRelation> relations = this.relationService.FindAll(patient.Id);
            //Delete all implementation to Generic Repository?
            this.container.Repository<UserPatientRelation>().Delete(relations);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Patient CreatePatient(PatientDto request)
        {
            User user = this.userService.Find(request.CreatedBy);
            Patient patient = new Patient
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Complaint = request.Complaint,
                Ssn = request.Ssn,
                CreatedBy = user
            };
            return patient;
        }

        public void Test2()
        {
            List<string> exception = null;
            exception.Add("Burak");
        }

    }
}
