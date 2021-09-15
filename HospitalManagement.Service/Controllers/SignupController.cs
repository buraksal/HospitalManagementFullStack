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
            //user managera git, doğru tipi seçip(user/patient etc. (enum kontrolünü yap!)) insert yap
            return null;
        }
    }
}
