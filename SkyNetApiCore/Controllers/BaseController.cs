using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkyNetApiCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
            //Here I put the notification object
        }

        protected virtual IActionResult CustomResponse(object result = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return Ok(new
            {
                code = HttpStatusCode.OK,
                data = result,   
                errors = new List<string> { } //"Success", "Error"
            });
        }

        protected void AddNotification()
        {

        }
       

    }
}
