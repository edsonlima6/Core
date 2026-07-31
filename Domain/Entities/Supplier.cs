using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : EntityBase
    {
        public Supplier()
        {
        }

        public Supplier(string companyName, string description, decimal servicePrice, int paymentInstallments)
        {
            CompanyName = companyName;
            Description = description;
            ServicePrice = servicePrice;
            PaymentInstallments = paymentInstallments;
            CreatedON = DateTime.Now;
        }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int PaymentInstallments { get; set; }

        public override (bool valid, string message) IsValid()
        {
            if (string.IsNullOrWhiteSpace(CompanyName))
                return (false, "CompanyName is required");

            if (ServicePrice <= 0)
                return (false, "ServicePrice must be greater than zero");

            if (PaymentInstallments <= 0)
                return (false, "PaymentInstallments must be greater than zero");

            return (true, string.Empty);
        }
    }
}
