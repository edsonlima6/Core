using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IEmpresaApplication _empresaApllication;
        private readonly IMapper _mapper;
        public SupplierController([FromServices]IEmpresaApplication empresaApllication,
                                 IMapper mapper)
        {
            _empresaApllication = empresaApllication; 
            _mapper = mapper;
        }

        [Authorize("Bearer")]
        [HttpGet("Supplier")]    
        public ActionResult GetSupplier()
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

        //[Authorize("Bearer")]
        [HttpPost("AddSupplier")]    
        public ActionResult AddSupplier(SupplierVM supplierVM)
        {
             try
             {   

                 var supp = _mapper.Map<Empresa>(supplierVM);
                 _empresaApllication.Add(supp);


                 return  Ok();
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        } 




    }
}