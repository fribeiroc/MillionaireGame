using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;

namespace IntegrationTest
{
    public class UrlTesting : IClassFixture<WebApplicationFactory<MillionaireGameMvc.Startup>>
    {
        //This creates a readonly instance of the MVC project, which I can use for the tests.
        private readonly WebApplicationFactory<MillionaireGameMvc.Startup> _factory;

        public UrlTesting(WebApplicationFactory<MillionaireGameMvc.Startup> factory)
        {
            _factory = factory;
        }

        //Theory can perform multiple tests which in this case have different parameters specified in InlineData tags
        [Theory]
        [InlineData("/")]
        [InlineData("/Questions")]
        [InlineData("/Answers")]
        [InlineData("/Categories")]
        public async Task TestEnpoints_HeaderContentType(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Questions")]
        [InlineData("/Answers")]
        [InlineData("/Categories")]
        public async Task TestEnpoints_StatusCode(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //Performs the test a single time and doesn't accept parameters as contrary to Theory tag
        [Fact]
        public async Task TestEnpoints_HomePage()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/");

            string result = await response.Content.ReadAsStringAsync();

            Assert.Contains("Welcome", result);
        }
    }
}
