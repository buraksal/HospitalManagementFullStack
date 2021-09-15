using HospitalManagement.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Controllers
{
    public class PatientController : ControllerBase
    {
        PatientService patientService = new PatientService();

        public IActionResult Index()
        {
            return Ok("Here");
        }
    }
}