using System.Text.Json.Nodes;
using BCUContosotimetable.Pages;
using BCUContosotimetable.Support;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BCUContosotimetable.StepDefinitions
{
    [Binding]
    public class UpdateStudentNameStepDefinitions
    {
        private readonly IPlaywrightService _playwrightService;
        private readonly IStudentDetailsPage _studentDetailsPage;
        private IAPIResponse _response;

        private const string API_ENDPOINT = "https://localhost:57839";
        private const string APP_URL = "https://localhost:7092/students";
        private string _studentId = "1";

        public UpdateStudentNameStepDefinitions(
            IPlaywrightService playwrightService,
            IStudentDetailsPage studentDetailsPage)
        {
            _playwrightService = playwrightService;
            _studentDetailsPage = studentDetailsPage;
        }

        [Given("a student exists with ID {string}")]
        public async Task GivenAStudentExistsWithID(string studentId)
        {
            _studentId = studentId;
            string apiUrl = $"{API_ENDPOINT}/student/{_studentId}";

            _response = await _playwrightService.Restendpoint.GetAsync(apiUrl, new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            }
            });

            Assert.IsTrue(_response.Ok, "API response was not successful.");
        }

        [When("I send a PUT request to update their name to {string}")]
        public async Task WhenISendAPUTRequestToUpdateTheirNameTo(string newName)
        {
            string apiUrl = $"{API_ENDPOINT}/student/{_studentId}/name?newName={newName}";

            _response = await _playwrightService.Restendpoint.PutAsync(apiUrl, new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            }
            });
        }

        [Then("the API should return a successful response")]
        public void ThenTheAPIShouldReturnASuccessfulResponse()
        {
            Assert.IsTrue(_response.Ok, "API response was not successful.");
        }

        [Then("the response body should contain the updated name {string}")]
        public async Task ThenTheResponseBodyShouldContainTheUpdatedName(string expectedName)
        {
            var json = JsonNode.Parse(await _response.TextAsync());
            Assert.AreEqual(expectedName, json["name"]?.ToString());
        }

        [When("I open the student details page for student with ID {string} in the web application")]
        public async Task WhenIOpenTheStudentDetailsPageForStudentWithIDInTheWebApplication(string p0)
        {
            await _studentDetailsPage.NavigateToStudentAsync(APP_URL);
            Assert.IsTrue(_studentDetailsPage.GetCurrentUrl().Contains("students"));
        }

        [Then("the student name should be displayed as {string}")]
        public async Task ThenTheStudentNameShouldBeDisplayedAs(string expectedStudentName)
        {
            await _studentDetailsPage.ClickViewButtonForFirstStudentAsync();
            var actualStudentName = await _studentDetailsPage.GetDisplayedStudentNameAsync();
            Assert.AreEqual(actualStudentName.Trim(), expectedStudentName);
        }
    }
}
