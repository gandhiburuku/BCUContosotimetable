using BCUContosotimetable.Support;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace BCUContosotimetable.Pages
{
    public interface IStudentDetailsPage
    {
        Task NavigateToStudentAsync(string applicationUrl);
        string GetCurrentUrl();
        Task ClickViewButtonForFirstStudentAsync();
        Task<string> GetDisplayedStudentNameAsync();
    }

    public class StudentDetailsPage : IStudentDetailsPage
    {
        private readonly IPlaywrightService _playwrightService;
        private readonly IPage _page;

        public StudentDetailsPage(IPlaywrightService playwrightService)
        {
            _playwrightService = playwrightService;
            _page = _playwrightService.Page;
        }

        private ILocator StudentName => _page.Locator("//h3");

        public async Task NavigateToStudentAsync(string applicationUrl)
        {
            await _page.GotoAsync(applicationUrl);
        }

        public string GetCurrentUrl()
        {
            return _page.Url;
        }

        public async Task ClickViewButtonForFirstStudentAsync()
        {
            await _page.ClickAsync("text=View >> nth=0");
            await _page.WaitForTimeoutAsync(5000);
        }

        public async Task<string> GetDisplayedStudentNameAsync()
        {
            return await StudentName.InnerTextAsync();
        }
    }
}
