using BCUContosotimetable.Pages;
using BCUContosotimetable.Support;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace BCUContosotimetable
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<IPlaywrightService, PlaywrightService>()
                .AddSingleton<IStudentDetailsPage, StudentDetailsPage>();

            return services;
        }
    }
}
