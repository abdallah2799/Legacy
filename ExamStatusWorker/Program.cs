using Data;
using ExamStatusWorker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Register your EF DbContext — connection string read from config or env
        // DbContext registration
        services.AddDbContext<LegacyDbContext>(options =>
        {
            options.UseSqlServer(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection"));
            options.UseLazyLoadingProxies(); // enable lazy loading
        });

        services.AddHostedService<ExamStatusUpdaterService>();
        services.AddHostedService<ExamNotificationWorker>();

    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build()
    .Run();
