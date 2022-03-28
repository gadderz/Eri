namespace Eri.Api.Configuration;

public static class ApplicationBuilderExtensions
{
    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}