using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNetAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class WeatherForecastController : ControllerBase
    {
        IUserHandler userHandler { get; set; }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserHandler _userHandler)
        {
            _logger = logger;
            //userHandler = _userHandler;
        }

        [HttpGet]
        public async Task<string[]> Get()
        {
            return Summaries;
        }
    }
}
