using Eri.Api.Web.Services;
using Eri.Core.Interfaces.Repository;
using Eri.Core.Services;
using Eri.Database;
using Eri.Database.Repository;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Eri.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddBase(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                o.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(s => s.FullName);
        });
    }

    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(_ =>
        {
            var mongodbContext = new Context(configuration.GetConnectionString("MongoDB"), configuration["DatabaseName"]);
            return mongodbContext;
        });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAnimeRepository, AnimeRepository>();
        services.AddTransient<ICharacterRepository, CharacterRepository>();
    }

    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<AnimeService>();
        services.AddTransient<CharacterService>();
    }

    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddTransient<AnimeWebService>();
        services.AddTransient<CharacterWebService>();
        services.AddTransient<ScrapingWebService>();
    }
}
