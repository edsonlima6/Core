using Application.Interfaces.Commands;
using MediatR;

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
