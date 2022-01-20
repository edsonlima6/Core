using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedON { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public virtual (bool valid, string message)  IsValid()
        {
            bool valid = false;

            return (valid, "");
        }



    }
}
