using HospitalManagement.Business;
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
    public class LogInController : ControllerBase
    {
        IUserService userService;
        [HttpGet]
        public ActionResult LogInControl()
        {
            return Ok("Successful Mail: asd");
        }

        [HttpPost]
        [Route("signin")]
        public ActionResult LogInControl(LoginDto logInRequest)
        {
            Boolean successful = userService.LogInControl(logInRequest);

            

            //user service git, getall ı çağır kontrolü yap?, kontrol businesste yapılmalı?
            return Ok("Your Email is not on our database" + successful);
        }
    }
}