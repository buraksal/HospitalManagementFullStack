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
    public class RelationService : IRelationService, IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IContainer container;

        public RelationService(IUnitOfWork unitOfWork, IContainer container)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
        }

        public IQueryable<UserPatientRelation> GetAll()
        {
            return this.container.Repository<UserPatientRelation>().Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public UserPatientRelation Find(string patientName)
        {
            var relation = this.container.Repository<UserPatientRelation>().Get(r => r.Patient.Name.Equals(patientName));
            return relation.ToList()[0];
        }

        public void Insert(PatientDto patient)
        {
            UserPatientRelation relation = CreateRelation(patient);
            this.container.Repository<UserPatientRelation>().Insert(relation);
            unitOfWork.Save();
        }

        public void Update(PatientDto patient)
        {
            UserPatientRelation relation = this.Find(patient.Ssn);
            this.container.Repository<UserPatientRelation>().Update(relation);
            unitOfWork.Save();
        }

        public void Delete(PatientDto patient)
        {
            UserPatientRelation relation = this.Find(patient.Ssn);
            this.container.Repository<UserPatientRelation>().Delete(relation);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        private UserPatientRelation CreateRelation(PatientDto request)
        {
            UserPatientRelation relation = new UserPatientRelation
            {
                Id = Guid.NewGuid(),
                //PatientName = request.Name,
                //UserName = request.CreatedBy,
                //Complaint = request.Complaint
            };
            return relation;
        }
    }
}
