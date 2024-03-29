﻿
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
        public User()
        {

        }
        public User(string name, string email, string lastName = null)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override (bool valid, string message) IsValid()
        {
            var status = (true, "");

            if (CreatedON <= DateTime.Now.Subtract(TimeSpan.FromDays(1)))
                status = (false, "Created date is required");

            if (string.IsNullOrEmpty(Name))
                status = (false, "Name is required");

            if (string.IsNullOrEmpty(LastName))
                status = (false, "LastName is required");

            if (string.IsNullOrEmpty(Email))
                status = (false, "Email is required");

            return status;
        }
    }
}
