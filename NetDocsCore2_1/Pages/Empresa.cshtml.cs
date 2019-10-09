using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeleHelp.Application.Interface;

namespace MyApp.Namespace
{
    public class EmpresaModel : PageModel
    {
        public SupplierVM _suppluer {get; private set;}

        readonly IEmpresaApplication _empresaApp;
        readonly IMapper _mapper;
        public EmpresaModel([FromServices]IEmpresaApplication empresaApllication, IMapper mapper)
        {
            _empresaApp = empresaApllication;
            _mapper = mapper;
            _suppluer = new SupplierVM();
        }
        public void OnGet()
        {
            try 
            {
                _suppluer.sRazaoSocial = "It Works";   
            }
            catch(Exception )
            {

            }
        }
    }
}