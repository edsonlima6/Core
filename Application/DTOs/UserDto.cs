using System;

namespace Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
