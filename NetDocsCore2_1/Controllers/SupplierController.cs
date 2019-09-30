using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyBI.Domain1.Entities;
using TeleHelp.Application.Interface;
using TeleHelp.Application.Services;

namespace NetDocsCore2_1.Controllers
{
    [Route("api/[controller]")] ///[action]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class SupplierController : ControllerBase
    {
        public readonly IEmpresaApplication _empresaApllication;
        public SupplierController([FromServices]IEmpresaApplication empresaApllication)
        {
            _empresaApllication = empresaApllication; 
        }

        [Authorize("Bearer")]
        [HttpGet("Supplier")]    
        public ActionResult GetSupplier()
        {
             try
             {   
                 var n2 = _empresaApllication.GetAll();
                 return  Ok();
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        } 

        [Authorize("Bearer")]
        [HttpPost("AddSupplier")]    
        public ActionResult AddSupplier(SupplierVM supplierVM)
        {
             try
             {   
                 //var n2 = _empresaApllication.GetAll();


                 return  Ok();
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        } 




    }
}