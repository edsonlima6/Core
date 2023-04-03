using Application.Commands;
using Domain.Specifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNetApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseController
    {
        public SupplierController(DomainNotification notifi, IMediator mediator) : base(notifi) {  _mediator = mediator; }
        readonly IMediator _mediator;


        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet("users")]
        //public async Task<IEnumerable<User>> GetUser()
        //{
        //    try
        //    {
        //        return await userHandler.GetAllAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        [HttpPost("create")]
        public async Task<IActionResult> AddSupplier()
        {
            try
            {
                await _mediator.Send(new CreateSupplierCommand() { IsValidSupplier = false });
                return CustomResponse();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
            }
        }

        //[HttpDelete("remove")]
        //public async Task<IActionResult> RemoveUser(int id)
        //{
        //    try
        //    {
        //        userHandler.Remove(id);
        //        return Ok(new { Data = new { msg = "OK" }, Msg = string.Empty });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
        //    }
        //}

    }
}
