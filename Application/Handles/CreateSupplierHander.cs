using Application.Commands;
using Domain.Specifications;
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
        DomainNotification notifi;
        public CreateSupplierHander(DomainNotification _notifi)
        {
            notifi = _notifi;
        }

        public Task<bool> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            request.IsValidSupplier = true;
            notifi.AddNotification("Created notification", "Domain");
            return Task.FromResult(request.IsValidSupplier);        
        }
    }
}
