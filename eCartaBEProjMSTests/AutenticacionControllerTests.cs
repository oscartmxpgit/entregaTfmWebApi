using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using eCartaBE.Controllers;
using eCartaBE.InfrastructuraSeguridad;
using eCartaBE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eCartaBE.Tests
{
    [TestClass]
    public class AutenticacionControllerTests
    {
        private readonly TestHostFixture _testHostFixture = new TestHostFixture();
        private HttpClient _httpClient;
        private IServiceProvider _serviceProvider;

        [TestInitialize]
        public void SetUp()
        {
            _httpClient = _testHostFixture.Client;
            _serviceProvider = _testHostFixture.ServiceProvider;
        }


        [TestMethod]
        public async Task LoginEmpleadoCorrecto()
        {
            var credentials = new LoginRequest
            {
                UserName = "Y8832807T",
                Password = "Misupersecreto1"
            };
            var loginResponse = await _httpClient.PostAsync("api/autenticacion/EmpleadoLogin",
                new StringContent(JsonSerializer.Serialize(credentials), Encoding.UTF8, MediaTypeNames.Application.Json));
            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

            var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<LoginResult>(loginResponseContent);
            Assert.AreEqual(credentials.UserName, loginResult.UserName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.AccessToken));
            
        }

        [TestMethod]
        public async Task DebeDelvolver401CredencialesNoValidas()
        {
            var credentials = new LoginRequest
            {
                UserName = "usuario",
                Password = "invalidPassword"
            };
            var response = await _httpClient.PostAsync("api/autenticacion/EmpleadoLogin",
                new StringContent(JsonSerializer.Serialize(credentials), Encoding.UTF8, MediaTypeNames.Application.Json));
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
