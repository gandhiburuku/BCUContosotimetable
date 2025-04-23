using Microsoft.Extensions.DependencyInjection;

namespace BCUContosotimetable.Support
{
    [Binding]
    public class Hooks
    {

        [BeforeTestRun(Order = 0)]
        public async static Task InitializePlaywright(IServiceProvider serviceProvider)
        {
            var playwrightService = serviceProvider.GetRequiredService<IPlaywrightService>();
            await playwrightService.InitializeAsync();
        }

        [AfterTestRun]
        public async static Task DisposePlaywright(IServiceProvider serviceProvider)
        {
            if (serviceProvider.GetService<IPlaywrightService>() is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync();
            }
        }
    }
}
