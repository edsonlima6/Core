
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("[User]")]
    public class User : EntityBase
    {
        public User(string name, string email, string lastName = null)
        {
            E_mail = new Email();
            Name = name;
            LastName = lastName;
            E_mail.E_mail = email;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get { return E_mail.E_mail; } set { E_mail.E_mail = value; } }

        private Email E_mail { get; set; }

        public override (bool valid, string message) IsValid()
        {
            bool isobjectvalid = true;
            return (isobjectvalid, "");
        }
    }
}
