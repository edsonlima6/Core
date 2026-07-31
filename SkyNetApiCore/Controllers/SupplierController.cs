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
            try
            {
                await domainEventPublisher.PublishAsync(command);
                return CustomResponse();
            }
            catch (Exception)
            {
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
            }
        }

        [HttpGet("hi")]
        public async Task<IActionResult> Hi()
        {
            return Ok(new { Data = new { msg = "OK" }, Msg = "Hello from SupplierController" });
        }
    }
}
