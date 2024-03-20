
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Wycieczki.Data;
using Microsoft.EntityFrameworkCore;
using Wycieczki.Models;

namespace Wycieczki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TripsContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.Configure(app =>
                            {
                                app.UseRouting();

                                app.UseHttpsRedirection();
                                app.UseStaticFiles();

                                app.UseAuthentication();
                                app.UseAuthorization();

                                app.UseEndpoints(endpoints =>
                                {
                                    endpoints.MapControllerRoute(
                                        name: "default",
                                        pattern: "{controller=Home}/{action=Index}/{id?}");
                                    endpoints.MapRazorPages();
                                });
                            });
                        })
                        .ConfigureServices((context, services) =>
                        {
                            services.AddDbContext<TripsContext>(options =>
                                options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                            services.AddDatabaseDeveloperPageExceptionFilter();

                            services.AddControllersWithViews();
                            services.AddRazorPages();
                        });
    }
}