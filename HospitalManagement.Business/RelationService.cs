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

        private readonly IPatientService patientService;

        private readonly IUserService userService;

        public RelationService(IUnitOfWork unitOfWork, IContainer container, IPatientService patientService, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.container = container;
            this.patientService = patientService;
            this.userService = userService;
        }

        public IQueryable<UserPatientRelation> GetAll()
        {
            return this.container.Repository<UserPatientRelation>().Get(orderBy: q => q.OrderBy(d => d.Id)).AsQueryable();
        }

        public UserPatientRelation Find(Guid id)
        {
            var relation = this.container.Repository<UserPatientRelation>().Get(r => r.Patient.Id.Equals(id)).FirstOrDefault();
            return relation;
        }

        public List<UserPatientRelation> FindAll(Guid id)
        {
            List<UserPatientRelation> result = this.container.Repository<UserPatientRelation>().Get(q => q.Id.Equals(id)).ToList();
            return result;
        }

        public void Insert(PatientDto patient)
        {
            UserPatientRelation relation = CreateRelation(patient);
            this.container.Repository<UserPatientRelation>().Insert(relation);
            unitOfWork.Save();
        }

        public void Update(PatientDto patient)
        {
            Patient patientObj = this.patientService.Find(patient.Ssn);
            UserPatientRelation relation = this.Find(patientObj.Id);
            this.container.Repository<UserPatientRelation>().Update(relation);
            unitOfWork.Save();
        }

        public void Delete(PatientDto patient)
        {
            Patient patientObj = this.patientService.Find(patient.Ssn);
            UserPatientRelation relation = this.Find(patientObj.Id);
            this.container.Repository<UserPatientRelation>().Delete(relation);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        private UserPatientRelation CreateRelation(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            UserPatientRelation relation = new UserPatientRelation
            {
                Id = Guid.NewGuid(),
                Patient = patient,
                User = patient.CreatedBy
            };
            return relation;
        }
    }
}
