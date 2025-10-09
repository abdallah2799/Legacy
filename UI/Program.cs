using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows.Forms;
using UI;
using UI.Infrastructure;
using UI.FormsLayer.Shared;
using UI.FormsLayer.Admin;
using MaterialSkin;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        // 1?? Create Host
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        // 2?? Initialize Infrastructure
        InitializeInfrastructure(ServiceProvider);

        // 3?? Standard WinForms startup
        System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        // 4?? Start with Splash Page
        var splashPage = new SplashPage();
        System.Windows.Forms.Application.Run(splashPage);
    }

    private static void InitializeInfrastructure(IServiceProvider serviceProvider)
    {
        // Initialize LocalizationManager
        LocalizationManager.Initialize(serviceProvider);
        
        // Initialize MaterialSkinManager
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Blue700,
            Primary.Blue800,
            Primary.Blue500,
            Accent.Blue400,
            TextShade.WHITE
        );

        // Initialize ThemeManager
        var themeManager = ThemeManager.Instance;
        themeManager.ApplyTheme(materialSkinManager);
    }

    // ?? Centralized host configuration
    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Application DI (DbContext, Repositories, Services)
                services.AddApplication(context.Configuration);

                // Register forms (with constructor injection)
                services.AddTransient<Form1>();
                services.AddTransient<SplashPage>();
                services.AddTransient<LoginForm>();
                services.AddTransient<MainDashboard>();
                services.AddTransient<ApplicantApplicationForm>();
                services.AddTransient<GuestPracticeForm>();
                services.AddTransient<BranchManagerApplicantReviewForm>();
                services.AddTransient<AdminApplicantFinalizationForm>();
                services.AddTransient<UserManagementForm>();
                services.AddTransient<UserDetailsForm>();
                services.AddTransient<BranchManagementForm>();
                services.AddTransient<TrackManagementForm>();
                services.AddTransient<UI.FormsLayer.Instructor.MyCoursesForm>();
                services.AddTransient<UI.FormsLayer.Instructor.ExamManagementForm>();
                services.AddTransient<UI.FormsLayer.Student.MyExamsForm>();
                services.AddTransient<UI.FormsLayer.Student.TakeExamForm>();
                services.AddTransient<UI.FormsLayer.Student.ExamResultsForm>();
                services.AddTransient<ReportViewerForm>();
            });
}
