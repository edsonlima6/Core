using Application.Commands;
using Application.DomainEvents;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handles
{
    public class CreateSupplierHander : IDomainEventHandler<CreateSupplierCommand>
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly DomainNotification notification;

        public CreateSupplierHander(ISupplierRepository supplierRepository, DomainNotification notification)
        {
            this.supplierRepository = supplierRepository;
            this.notification = notification;
        }

        public async Task HandleAsync(CreateSupplierCommand request, CancellationToken cancellationToken = default)
        {
            var supplier = new Supplier(
                request.CompanyName,
                request.Description,
                request.ServicePrice,
                request.PaymentInstallments);

            var validation = supplier.IsValid();
            if (!validation.valid)
            {
                notification.AddNotification(validation.message, "Domain");
                return;
            }

            await supplierRepository.InsertAsync(supplier);
            supplierRepository.SaveChanges();
        }
    }
}
