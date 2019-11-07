using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeleHelp.Application.Interface;

namespace MyApp.Namespace
{
    public class SupplierModel : PageModel
    {
         [BindProperty]
        public SupplierVM _supplier {get; private set;}
        public readonly IEmpresaApplication _empresaApllication;
        
        public SupplierModel([FromServices]IEmpresaApplication empresaApllication)
        {
            _empresaApllication = empresaApllication;
        }
       

        public void OnGet()
        {
            var empresa = _empresaApllication.GetAll();
            
             _supplier = new SupplierVM(){sRazaoSocial = "ENEL"};
        }
    }
}