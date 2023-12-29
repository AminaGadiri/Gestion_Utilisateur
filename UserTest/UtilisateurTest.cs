using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
//using TestASPNetMVC;
using System.Net;
using System.Text.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace UserTest
{
    public class UtilisateurTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public UtilisateurTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task Get_Existing_User_Returns_200()
        {
            //Arrange
            var WireMockSvr = WireMockServer.Start();

            var Factory = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("UserUrl", WireMockSvr.Url);
                });

            var HttpClient = Factory.CreateClient();

            Fixture fixture = new Fixture();

            var ResponseObj = fixture.Create<UtilisateurDto>();
            var ResponseObjJson = JsonSerializer.Serialize(ResponseObj);

            WireMockSvr
                .Given(Request.Create()
                    .WithPath("/Utilisateur")
                    .UsingGet())
                .RespondWith(Response.Create()
                    .WithBody(ResponseObjJson)
                    .WithHeader("Content-Type", "application/json")
                    .WithStatusCode(HttpStatusCode.OK));

            //Act
            var HttpResponse = await HttpClient.GetAsync("/Utilisateur");

            //Assert
            HttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var ResponseJson = await HttpResponse.Content.ReadAsStringAsync();
            var UtilisateurDto = JsonSerializer.Deserialize<UtilisateurDto>(ResponseJson);

            UtilisateurDto.Should().BeEquivalentTo(ResponseObj);

            WireMockSvr.Stop();
        }
    }
}