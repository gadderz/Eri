using Eri.Api.Configuration;
using Eri.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBase();
builder.Services.AddSwagger();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddCoreServices();
builder.Services.AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
    c.AllowAnyHeader();
});

app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
