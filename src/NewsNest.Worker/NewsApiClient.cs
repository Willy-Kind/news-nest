using System.Net.Http.Headers;

namespace NewsNest.Worker;

public class NewsApiClient(HttpClient client) : INewsApiClient
{
    public async Task GetNews()
    {
        var result = await client.GetAsync("v2/top-headlines?country=us");
    }
}

public interface INewsApiClient
{
    Task GetNews();
}

public static class NewsApiClientConfigurationExtensions
{
    public static IServiceCollection AddNewsApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddHttpClient<INewsApiClient, NewsApiClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["NewsApi:BaseAddress"]!);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", configuration["NewsApi:ApiKey"]);
            })
            .Services;
    }
}