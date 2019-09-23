using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TeleHelp.Application.Services;

namespace NetDocsCore2_1.Controllers
{
    [Route("api/[controller]")] ///[action]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class SupplierController : ControllerBase
    {
        public readonly EmpresaApllication _empresaApllication;
        public SupplierController(EmpresaApllication empresaApllication)
        {
            _empresaApllication = empresaApllication;
        }


        [AllowAnonymous]
        [HttpGet("Supplier")]    
        public ActionResult GetSupplier(string n = "")
        {
             try
             {   
                 var n2 = _empresaApllication.GetAll();
                 return  Ok(n2);
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        } 




    }
}