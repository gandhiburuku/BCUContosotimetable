using Microsoft.Playwright;

namespace BCUContosotimetable.Support
{
    public interface IPlaywrightService
    {
        IPlaywright Playwright { get; }
        IBrowser Browser { get; }
        IPage Page { get; }
        IAPIRequestContext Restendpoint { get; }
        Task InitializeAsync();
    }
    public class PlaywrightService: IPlaywrightService, IAsyncDisposable
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }
        public IPage Page { get; private set; }
        public IAPIRequestContext Restendpoint { get; private set; }

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            Page = await Browser.NewPageAsync();
            Restendpoint = await Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                IgnoreHTTPSErrors = true
            });
        }

        public async ValueTask DisposeAsync()
        {
            if (Restendpoint != null)
                await Restendpoint.DisposeAsync();

            if (Browser != null)
                await Browser.DisposeAsync();

            Playwright?.Dispose();
        }
    }
}
