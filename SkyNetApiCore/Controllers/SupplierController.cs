using Application.Commands;
using Application.DomainEvents;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SkyNetApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseController
    {
        private readonly IDomainEventPublisher domainEventPublisher;

        public SupplierController(DomainNotification notifi, IDomainEventPublisher domainEventPublisher) : base(notifi)
        {
            this.domainEventPublisher = domainEventPublisher;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddSupplier(CreateSupplierCommand command)
        {
            await domainEventPublisher.PublishAsync(command);
            return CustomResponse();
        }

        [HttpGet("hi")]
        public async Task<IActionResult> Hi() =>
             Ok(new { Data = new { msg = "OK" }, Msg = "Hello from SupplierController" });

        [HttpGet("error")]
        public async Task<IActionResult> GetExceptionError() =>
          throw new ArgumentNullException("This is a fake error, hangled by middlware");
    }
}
