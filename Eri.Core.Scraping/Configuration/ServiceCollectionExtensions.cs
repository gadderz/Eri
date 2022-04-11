using Eri.Core.Scraping.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using System.Net;

namespace Eri.Core.Scraping.Configuration;

public static class ServiceCollectionExtensions
{
    private static IAsyncPolicy<HttpResponseMessage> GetRetryHttpPolicy()
    {
        var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(delay);
    }

    public static void AddScrapingHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<JikanClient>(o =>
        {
            o.BaseAddress = new Uri(configuration["JikanBaseUri"]);
        })
            .AddPolicyHandler(GetRetryHttpPolicy());
    }

    public static void AddScrapping(this IServiceCollection services)
    {
        services.AddTransient<Jikan>();
    }
}
