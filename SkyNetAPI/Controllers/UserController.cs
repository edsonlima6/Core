using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkyNetAPI.Controllers
{
    [Route("api/SkyAuth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserHandler userHandler;
        public UserController(IUserHandler _userHandler)
        {
            userHandler = _userHandler;
        }
        // GET: api/<UserController> [controller]
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            try
            {
                var tes = await userHandler.GetAllAsync();

                return tes.Select(u => u.Email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Edson";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
