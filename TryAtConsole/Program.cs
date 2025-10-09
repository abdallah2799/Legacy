using Application;
using Core.Models;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TryAtConsole;
class Program
{
    static async Task Main(string[] args)
    {
        // 1️⃣ Build Host for Dependency Injection
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                // Load appsettings.json from the console app's directory
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Register all layers (DbContext, Repos, Services)
                services.AddApplication(context.Configuration);
            })
            .Build();

        // 2️⃣ Resolve Service
        var courseService = host.Services.GetRequiredService<ICourseService>();
        var userService = host.Services.GetRequiredService<IUserService>();


        // 3️⃣ Use It
        await RunDemoAsync(courseService);
    }

    static async Task RunDemoAsync(ICourseService courseService)
    {
        //Console.WriteLine("=== Courses Data Console ===\n");
        ////var courses = await courseService.GetAllCoursesAsync();
        var db = new Data.LegacyDbContextFactory().CreateDbContext([]);
        //var courses = db.Courses.ToList();
        //var instructors = db.Instructors.ToList();
        //var instructorCourses = db.InstructorCourses.ToList();
        //foreach (var course in courses)
        //{
        //    Console.WriteLine($"Course ID: {course.CourseId}, Title: {course.Name}, Description: {course.Description}");
        //}
        //Console.WriteLine("\n=== End of Data ===");
        //foreach (var instructor in instructors)
        //{
        //    Console.WriteLine($"Instructor ID: {instructor.UserId}, Name: {instructor.FullName}");
        //}
        //Console.WriteLine("\n=== End of Data ===");
        //foreach (var ic in instructorCourses)
        //{
        //    Console.WriteLine($"InstructorCourse ID: {ic.InstructorCourseId}, Instructor ID: {ic.InstructorId}, Course ID: {ic.CourseId}");
        //}
        //Console.WriteLine("\n=== End of Data ===");
        var trackCourses = db.TrackCourses.ToList();
        foreach (var tc in trackCourses)
        {
            Console.WriteLine($"TrackCourse ID: {tc.TrackCourseId}, Track ID: {tc.TrackId}, Course ID: {tc.CourseId}");
        }
    }
}


//using Data;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;
//Stopwatch stopwatch = Stopwatch.StartNew();
//var db = new LegacyDbContextFactory().CreateDbContext([]);

//Stopwatch sw = Stopwatch.StartNew();
//Console.WriteLine("Fetching user...");
//var user = await db.Users.FirstOrDefaultAsync(s => s.UserId == 6);
//sw.Stop();
//Console.WriteLine($"User fetched in {sw.ElapsedMilliseconds} ms.");
//sw.Restart();
//var user2 = await db.Users.FirstOrDefaultAsync(s => s.UserId == 6);
//sw.Stop();
//Console.WriteLine($"User fetched in {sw.ElapsedMilliseconds} ms.");
//sw.Restart();
//var user3 = await db.Users.FirstOrDefaultAsync(s => s.UserId == 6);
//sw.Stop();
//Console.WriteLine($"User fetched in {sw.ElapsedMilliseconds} ms.");
//sw.Restart();
//var user4 = await db.Users.FirstOrDefaultAsync(s => s.UserId == 6);
//sw.Stop();
//Console.WriteLine($"User fetched in {sw.ElapsedMilliseconds} ms.");
//stopwatch.Stop();
//Console.WriteLine($"Total execution time: {stopwatch.ElapsedMilliseconds} ms.");