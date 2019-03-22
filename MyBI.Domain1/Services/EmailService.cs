using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class EmailService : ServiceBase<Email>, IEmailService
    {

        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
            : base(emailRepository)
        {
            _emailRepository = emailRepository;
        }

    }
}
