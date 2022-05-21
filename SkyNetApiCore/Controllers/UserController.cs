using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNetApiCore.Controllers
{
    [ApiController]
    [Route("skyhub/user")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;

        IUserHandler userHandler;
        public UserController(ILogger<UserController> logger, IUserHandler _userHandler)
        {
            _logger = logger;
            userHandler = _userHandler;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("users")]
        public async Task<IEnumerable<User>>GetUser() 
        {
            try
            {
                return await userHandler.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await userHandler.AddAsync(user);
                return Ok(new { Data = new { msg = "OK" }, Msg = string.Empty });
            }
            catch (Exception ex)
            {
                string msf = ex.Message;
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend"});
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                userHandler.Remove(id);
                return Ok(new { Data = new { msg = "OK" }, Msg = string.Empty });
            }
            catch (Exception)
            {
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
            }
        }
    }
}
