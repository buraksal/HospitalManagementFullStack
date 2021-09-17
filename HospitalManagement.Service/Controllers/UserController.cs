using HospitalManagement.Business;
using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IRelationService relationService;

        public UserController(IPatientService patientService, IRelationService relationService)
        {
            this.patientService = patientService;
            this.relationService = relationService;
        }

        [HttpGet]
        [Route("getPatientList")]
        public List<Patient> GetPatientList()
        {
            List<Patient> patientList = this.patientService.GetAll().ToList<Patient>();
            return patientList;
        }

        [HttpPost]
        [Route("createpatient")]
        public IActionResult CreatePatient(PatientDto request)
        {
            Patient patient = CreatedPatient(request);
            this.patientService.Insert(patient);
            UserPatientRelation relation = CreateRelation(request);
            this.relationService.Insert(relation);
            return Ok("Patient with SSN "+ patient.Ssn + " created!");
        }

        [HttpPost]
        [Route("getPatient")]
        public Patient GetPatient(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            return patient;
        }

        [HttpPut]
        [Route("updatePatient")]
        public IActionResult UpdatePatient(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            this.patientService.Update(patient);
            if((patient.Name != request.Name) || (patient.CreatedBy != request.CreatedBy))
            {
                UserPatientRelation relation = this.relationService.Find(patient.Name);
                this.relationService.Update(relation);
            }
            return Ok("Updated!");
        }

        [HttpDelete]
        [Route("deletePatient")]
        public IActionResult DeletePatient(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            this.patientService.Delete(patient);
            UserPatientRelation relation = this.relationService.Find(request.Name);
            this.relationService.Delete(relation);
            return Ok("Deleted!");
        }

        private Patient CreatedPatient(PatientDto request)
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

        private UserPatientRelation CreateRelation(PatientDto request)
        {
            UserPatientRelation relation = new UserPatientRelation
            {
                Id = Guid.NewGuid(),
                PatientName = request.Name,
                UserName = request.CreatedBy,
                Complaint = request.Complaint
            };
            return relation;
        }

    }
}
