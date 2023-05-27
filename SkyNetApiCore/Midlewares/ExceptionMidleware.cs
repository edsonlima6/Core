using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SkyNetApiCore.Midlewares
{
    public class ExceptionMidleware
    {
        readonly RequestDelegate _next;
        readonly ILogger _logger;
        public ExceptionMidleware(RequestDelegate Next, ILoggerFactory logFactory)
        {
            _next = Next;
            _logger = logFactory.CreateLogger("MyMiddleware");
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                _logger.LogInformation("MyMiddleware executing..");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType= "application/json";
                var json = JsonConvert.SerializeObject(new { StatusCode = HttpStatusCode.InternalServerError, Errors = ex.Message });
                _logger.LogInformation($"MyMiddleware Error:..{ex.Message}");
                await httpContext.Response.WriteAsync(json);
            }
          
        }
    }
}
