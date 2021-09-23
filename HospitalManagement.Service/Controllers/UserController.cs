using AutoMapper;
using HospitalManagement.Business;
using HospitalManagement.Business.Interfaces;
using HospitalManagement.Data;
using HospitalManagement.Data.DTO;
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
        private readonly IMapper mapper;

        public UserController(IPatientService patientService, IRelationService relationService, IMapper mapper)
        {
            this.patientService = patientService;
            this.relationService = relationService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("getPatientList")]
        public List<PatientDto> GetPatientList()
        {
            List<Patient> patientList = this.patientService.GetAll().ToList();
            List<PatientDto> retVal = mapper.Map<List<Patient>, List<PatientDto>>(patientList);
            return retVal;
        }

        [HttpPost]
        [Authorize]
        [Route("createpatient")]
        public IActionResult CreatePatient(PatientDto request)
        {
            this.patientService.Insert(request);
            return Ok("Patient with SSN " + request.Ssn + " created!");
        }

        [HttpPost]
        //[Authorize]
        [Route("getPatientListPagination")]
        public IActionResult GetPatientListPagination(PaginationDto request)
        {
            List<Patient> patientList = this.patientService.GetWithPagination(request).ToList();
            List<PatientDto> retVal = mapper.Map<List<Patient>, List<PatientDto>>(patientList);
            return Ok(retVal);
        }

        [HttpPost]
        [Authorize]
        [Route("getPatient")]
        public IActionResult GetPatient(PatientDto request)
        {
            Patient patient = this.patientService.Find(request.Ssn);
            PatientDto retVal = mapper.Map<PatientDto>(patient);
            return Ok(retVal);
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

        [HttpPost]
        [Route("test1")]
        public void Test1()
        {
            List<string> exception = null; 
            exception.Add("Burak");
        }

        [HttpPost]
        [Route("test2")]
        public void Test2()
        {
            this.patientService.Test2();
        }

    }
}
