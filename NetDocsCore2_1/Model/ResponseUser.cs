using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NetDocsCore2_1.Model
{
    public class ResponseUser
    {
        public User user {get; set;}    
        public IEnumerable<IdentityError> messages { get; set;}

        public bool created {get; set;}
    }
}