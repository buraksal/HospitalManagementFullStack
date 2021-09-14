using HospitalManagement.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Controllers
{
    [ApiController]
    [Route("login")]
    public class LogInController : Controller
    {
        [HttpGet]
        public ActionResult LogInControl()
        {
            return Ok("Successful Mail: asd");
        }

        [HttpPost]
        [Route("signin")]
        public ActionResult LogInControl(LoginDto logInRequest)
        {
            //user managera git, getall ı çağır kontrolü yap?
            return Ok("Your Email is not on our database");
        }
    }
}
