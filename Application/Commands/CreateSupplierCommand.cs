using Application.Interfaces.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateSupplierCommand : IRequest<bool>, ICreateSupplierCommand
    { 
        
        public bool IsValidSupplier { get; set; }
        public CreateSupplierCommand()
        {
            
        }


    }
}
