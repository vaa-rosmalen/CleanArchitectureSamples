using FullCleanProject.IntegrationTests.Helpers;
using System.Net;
using System.Threading.Tasks;
using FullCleanProject.Web;
using FluentAssertions;
using Xunit;

namespace FullCleanProject.IntegrationTests.Web.Pages
{
    public class IndexShould : BaseIntegrationTest<Startup>
    {
        public IndexShould(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnOk()
        {
            var response = await HttpClient.GetAsync("/");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
