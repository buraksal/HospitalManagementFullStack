using HospitalManagement.Business;
using HospitalManagement.Data;
using HospitalManagement.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignUpController : ControllerBase
    {
        private readonly IUserService userService;

        public SignUpController(IUserService userService)
        {
            //userService = new UserService(unitOfWork);
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult SignUpControl()
        {
            //user managera git, getallı çağır kontrolü yap?
            return Ok("Successful Mail: asd");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(SignupDto request)
        {
            Boolean successful = userService.SignUp(request);

            return Ok("Is Successful: " + successful);
        }
    }
}
