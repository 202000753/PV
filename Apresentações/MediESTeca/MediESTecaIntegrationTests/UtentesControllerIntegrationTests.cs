using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MediESTecaIntegrationTests
{
    public class UtentesControllerIntegrationTests 
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public UtentesControllerIntegrationTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
        }

        [Fact]
        public async Task Index_WhenNonAuthenticatedUser_IsRediretctedToLoginPage()
        {
            // Act: request the "/Utentes" route
            var httpResponse = await _client.GetAsync("/Utentes");

            // Assert: 
            Assert.Equal(HttpStatusCode.Redirect, httpResponse.StatusCode);
            Assert.StartsWith("http://localhost/Identity/Account/Login",
                httpResponse.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Index_WhenAuthenticatedUser_CanAccessPage()
        {
            UserAthentication userLogin = new UserAthentication(_client);
            userLogin.AuthenticateUser("jonas@ip.pt", "123456").Wait();

            // Act: request the "/Utentes" route
            var httpResponse = await _client.GetAsync("/Utentes");

            // Assert: 
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
