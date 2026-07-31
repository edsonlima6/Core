using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNetApiCore.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> logger;
        private readonly IUserHandler userHandler;

        public UserController(ILogger<UserController> logger, IUserHandler userHandler)
        {
            this.logger = logger;
            this.userHandler = userHandler;
        }

        [HttpGet("{id}")]
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
        public async Task<IEnumerable<UserDto>> GetUser()
        {
            return await userHandler.GetAllAsync();
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser(CreateUserDto user)
        {
            try
            {
                await userHandler.AddAsync(user);
                return Ok(new { Data = new { msg = "OK" }, Msg = string.Empty });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Could not create user");
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                await userHandler.RemoveAsync(id);
                return Ok(new { Data = new { msg = "OK" }, Msg = string.Empty });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Could not remove user");
                return BadRequest(new { Data = new { msg = "KO" }, Msg = "Ops something is wrong on backend" });
            }
        }
    }
}
