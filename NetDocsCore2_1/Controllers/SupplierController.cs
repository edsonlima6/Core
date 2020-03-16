using System;
using System.Collections.Generic;
using System.Linq;
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

        //[Authorize("Bearer")]
        [HttpGet("Suppliers")]    
        public async Task<ActionResult> GetSupplier()
        {
             try
             {   
                 IEnumerable<Empresa> n2 = await _empresaApllication.GetAllAsync();

                if (n2 != null && n2.Count() == 0)
                {
                    List<Empresa> listempresa = new List<Empresa>();
                    listempresa.Add(new Empresa { sRazaoSocial = "Edson Consultoria" });
                    n2 = listempresa;
                }
                 return  Ok(n2);
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        }

        [Authorize("Bearer")]
        [HttpGet("/{id}/Supplier")]        
        public async Task<ActionResult> GetSupplierByID(int id)
        {
            try
            {
                var n2 = await _empresaApllication.GetByIdAsync(id);
                return Ok(n2);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPost("AddSupplier")]    
        public async Task<ActionResult> AddSupplier(SupplierVM supplierVM)
        {
             try
             {   
                 var supp = _mapper.Map<Empresa>(supplierVM);
                 await _empresaApllication.Add(supp);
                 return  Ok(supp);
             }
             catch(Exception e)
             {
                return Unauthorized(e.Message);
             }
        }

        [Route("/{id}/RemoveSupplier")]
        [HttpDelete("RemoveSupplier")]
        public async Task<ActionResult> RemoveSupplier(SupplierVM supplierVM)
        {
            try
            {
                var supp = _mapper.Map<Empresa>(supplierVM);
                _empresaApllication.Delete(supp);
                return Ok(supp);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }




    }
}