using Microsoft.AspNetCore.Mvc;

namespace SkynetProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        return Ok(new { message = "Hello from SkynetProductsApi" });
    }
}
