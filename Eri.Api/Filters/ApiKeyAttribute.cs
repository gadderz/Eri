using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eri.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKeyHeader = "Api-Key";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //var env = context.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
        //if (env.IsDevelopment())
        //    return;


        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var potentialApiKey))
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = configuration["ApiKey"];

        if(potentialApiKey != apiKey)
        {
            context.Result = new StatusCodeResult(403);
            return;
        }

        await next();
    }
}
