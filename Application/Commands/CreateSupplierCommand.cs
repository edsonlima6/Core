using Application.DomainEvents;

namespace Application.Commands
{
    public class CreateSupplierCommand : IDomainEvent
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int PaymentInstallments { get; set; }
    }
}
