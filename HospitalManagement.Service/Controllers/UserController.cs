using HospitalManagement.Business;
using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using HospitalManagement.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
            this.patientService.Insert(request);
            this.relationService.Insert(request);
            return Ok("Patient with SSN " + request.Ssn + " created!");
        }

        [HttpPost]
        [Authorize]
        [Route("getPatient")]
        public Patient GetPatient(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            return patient;
        }

        [HttpPut]
        [Authorize]
        [Route("updatePatient")]
        public IActionResult UpdatePatient(PatientDto request)
        {
            this.patientService.Update(request);
            return Ok("Updated!");
        }

        [HttpDelete]
        [Authorize(Roles = "Doctor")]
        [Route("deletePatient")]
        public IActionResult DeletePatient(PatientDto request)
        {
            this.patientService.Delete(request);
            return Ok("Deleted!");
        }

    }
}
