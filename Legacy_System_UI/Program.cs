using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Legacy_System_UI;
using Legacy_System_UI.Infrastructure;
using Legacy_System_UI.Pages.Shared;
using Legacy_System_UI.Pages.Admin;
using Legacy_System_UI.Pages.Student;
using Legacy_System_UI.Pages.Instructor;
using Legacy_System_UI.Pages.Guest;
using MaterialSkin;

internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        // --- Ensure TLS 1.2 (needed for Office365 SMTP) ---
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        // --- Build Host and configure DI ---
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        // --- Initialize theme and localization infrastructure ---
        InitializeInfrastructure(ServiceProvider);

        // --- Standard WinForms startup ---
        System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        // --- Start the application with Splash / Startup form ---
        var startupForm = ServiceProvider.GetRequiredService<StartupForm>();
        System.Windows.Forms.Application.Run(startupForm);
    }

    private static void InitializeInfrastructure(IServiceProvider serviceProvider)
    {
        // Initialize Localization Manager
        LocalizationManager.Initialize(serviceProvider);

        // Initialize MaterialSkin Manager
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Blue700,
            Primary.Blue800,
            Primary.Blue500,
            Accent.Blue400,
            TextShade.WHITE
        );

        // Apply theme via ThemeManager
        var themeManager = ThemeManager.Instance;
        themeManager.ApplyTheme(materialSkinManager);
    }

    // --- Centralized Host Builder ---
    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Add Application layer (DbContext, Services, etc.)
                services.AddApplication(context.Configuration);

                // Register WinForms with DI
                services.AddTransient<StartupForm>();
                services.AddTransient<AdminMainForm>();
                services.AddTransient<StudentMainForm>();
                services.AddTransient<InstructorMainForm>();
                services.AddTransient<LoginForm>();
                services.AddTransient<ApplianceMainForm>();
                services.AddTransient<QuestionBankForm>();
            });
}
