using System.Net.Http;
using Xunit;

namespace FullCleanProject.IntegrationTests.Helpers
{
    public class BaseIntegrationTest<TStartup> : IClassFixture<CustomWebApplicationFactory<TStartup>> where TStartup : class
    {
        public readonly HttpClient HttpClient;

        public BaseIntegrationTest(CustomWebApplicationFactory<TStartup> factory) =>
            HttpClient = factory.CreateClient();
    }
}