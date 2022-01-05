using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using ViewWebsiteService;
using Xunit;

namespace Tests
{
    public class IntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {

        private readonly TestingWebAppFactory<Startup> _client;

        public IntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory;
        }

    [Fact]
        public async Task CreateWebsite()
        {
            var client = _client.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Act
            var response = await client.GetAsync("/site/viewpage/test.com/testpage");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("testpage", responseString);
            client.Dispose();
        }
    }
}
