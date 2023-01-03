using Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handles
{
    public class CreateSupplierHander : IRequestHandler<CreateSupplierCommand, bool>
    {
        public CreateSupplierHander()
        {
            
        }

        public Task<bool> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            request.IsValidSupplier = true;
            return Task.FromResult(request.IsValidSupplier);        
        }
    }
}
