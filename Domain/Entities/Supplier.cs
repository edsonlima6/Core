using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : EntityBase
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int PaymentInstallments { get; set; }


    }
}
