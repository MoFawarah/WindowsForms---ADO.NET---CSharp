
namespace BackGroundService.Services
{
    public class EmailBGService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Background Service is running at: {DateTimeOffset.Now}");
                //logic

                // Simulate sending an email every 5 minutes
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
