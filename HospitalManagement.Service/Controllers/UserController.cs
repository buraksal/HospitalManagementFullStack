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
    [Route("doctor")]
    public class UserController : Controller
    {


        [HttpGet]
        [Route("getPatientList")]
        public List<Patient> GetPatientList()
        {
            //patient managera git, getall yap
            return null;
        }

        [HttpPost]
        [Route("createpatient")]
        public IActionResult CreatePatient(PatientDto request)
        {
            //patient managera git, insert yap
            return null;
        }


        [HttpPost]
        [Route("getPatient")]
        public Patient GetPatient(PatientDto request)
        {
            //patient managera git, findbyid yap
            return null;

        }

        [HttpPut]
        [Route("updatePatient")]
        public IActionResult UpdatePatient(PatientDto request)
        {
            //patient managera git, update yap
            return null;
        }

        [HttpDelete]
        [Route("deletePatient")]
        public IActionResult DeletePatient(PatientDto request)
        {
            //patient managera git, delete yap
            return null;
        }

    }
}
