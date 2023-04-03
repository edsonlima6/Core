using Domain.Specifications;
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
    public class BaseController : ControllerBase, IDisposable
    {
        readonly DomainNotification notification; 
        public BaseController(DomainNotification _notification)
        {
            //Here I put the notification object
            notification = _notification;
        }

        public void Dispose()
        {
           notification.CleanNotification();
        }

        protected virtual IActionResult CustomResponse(object result = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            if (notification.HasNotification())
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    data = string.Empty,
                    errors = notification.Notifications.Select(c => c.Message)
                });

            return Ok(new
            {
                code = HttpStatusCode.OK,
                data = result
            });

        }

        protected bool HasNotification() => this.notification.HasNotification();
       

    }
}
