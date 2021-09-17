using HospitalManagement.Business;
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
    [Route("login")]
    public class LogInController : ControllerBase
    {
        private readonly IUserService userService;

        public LogInController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult LogInControl()
        {
            return Ok("Successful Mail: asd");
        }

        [HttpPost]
        [Route("signin")]
        public ActionResult LogInControl(LoginDto logInRequest)
        {
            var user = userService.LogInControl(logInRequest);
            if(user != null)
            {
                return Ok(user);
            }
            return Ok("Unsuccessful LogIn Attempt");
            
        }
    }
}