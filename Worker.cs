using Google.Apis.Drive.v3;

namespace DailyTaskService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _config;

    public Worker(ILogger<Worker> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int hour = _config.GetValue<int>("hour");
        int minute = _config.GetValue<int>("minute");
        DateTime now = DateTime.Now;
        DateTime targetTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);

        // If the target time has already passed today, schedule for tomorrow
        if (now > targetTime)
        {
            targetTime = targetTime.AddDays(1);
        }

        // Calculate the delay until the target time
        TimeSpan initialDelay = targetTime - now;
        
        // Timer to trigger every 24 hours
        var timer = new System.Threading.Timer(
            async _ =>
            {
                // Run your daily task here
                _logger.LogInformation("Running daily task: {Time}", DateTimeOffset.Now);
                await RunDailyTask();
            },
            null,
            initialDelay,
            TimeSpan.FromDays(1) // TimeSpan of 1 day (24 hours)
        );

        // Keep the service running
        await Task.Delay(Timeout.Infinite, stoppingToken);
        //while (!stoppingToken.IsCancellationRequested)
        //{
        //    if (_logger.IsEnabled(LogLevel.Information))
        //    {
        //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //    }
        //    await Task.Delay(1000, stoppingToken);
        //}
    }

    private async Task RunDailyTask()
    {
        try
        {
            // Your daily task logic goes here
            //await Task.Delay(1000); // Simulate some async work

            string filePath = _config.GetValue<string>("backupLocation"); // Specify network path

            _logger.LogInformation("GoogleDriveUploader Authentication Started");
            // Authenticate and get Drive service
            DriveService service = GoogleDriveUploader.Authenticate();
            _logger.LogInformation("GoogleDriveUploader Authentication Completed");

            _logger.LogInformation("FileUploader File Upload Started");

           string fileId =  FileUploader.CreateFolder(_logger,service, "Data_"+DateTime.Now.Day+DateTime.Now.Month+DateTime.Now.Year);
            // Upload file
           FileUploader.UploadFileAsync(_logger,service, fileId, filePath);
            _logger.LogInformation("FileUploader File Upload Completed");

            _logger.LogInformation("Daily task completed at: {Time}", DateTimeOffset.Now);
        }
        catch (Exception ex)
        {
            _logger.LogError("An Error Occured ", ex);
        }
    }
}
