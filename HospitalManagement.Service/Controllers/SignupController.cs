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
    public class SignupController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;


        public SignupController()
        {
            userService = new UserService(unitOfWork);
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

            return Ok("Your Email is not on our database" + successful);
        }
    }
}
