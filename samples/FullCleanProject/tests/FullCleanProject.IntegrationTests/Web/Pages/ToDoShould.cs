using FullCleanProject.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using FullCleanProject.Web;
using Xunit;

namespace FullCleanProject.IntegrationTests.Web.Pages
{
    public class ToDoShould : BaseIntegrationTest<Startup>
    {
        public ToDoShould(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnOk()
        {
            var response = await HttpClient.GetAsync("/todo");
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
