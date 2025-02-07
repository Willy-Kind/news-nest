namespace NewsNest.Worker;

public class Worker(ILogger<Worker> logger, INewsApiClient client) : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await client.GetNews();
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}