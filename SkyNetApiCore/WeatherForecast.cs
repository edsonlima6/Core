using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using SkyNetApiCore.Midlewares;
using System;

namespace SkyNetApiCore
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public static class CollectionData
    {
        public static IApplicationBuilder AddMidleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMidleware>();            
        }
    }
}
