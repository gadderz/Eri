namespace Eri.Api.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    private const string API_KEY_HEADER = "Api-Key";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var isDev = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        if (isDev)
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            return;
        }

        var configuration = context.RequestServices.GetRequiredService<IConfiguration>();

        if (!configuration["ApiKey"].Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            return;
        }

        await _next(context);
    }
}
