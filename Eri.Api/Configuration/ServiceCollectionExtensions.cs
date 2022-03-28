using Eri.Core.Interfaces.Repository;
using Eri.Core.Services;
using Eri.Database;
using Eri.Database.Repository;

namespace Eri.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddBase(this IServiceCollection services)
    {
        services.AddControllers();
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
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
}
