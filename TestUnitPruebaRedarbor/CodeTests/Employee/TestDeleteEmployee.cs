using Newtonsoft.Json;
using PruebaRedarbor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestUnitPruebaRedarbor.Shared;

namespace TestUnitPruebaRedarbor.CodeTests.Employee
{
    public class TestDeleteEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestDeleteEmployee(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TestApi.token);
            var response = await _client.DeleteAsync($"{TestApi.urlEndpoint}/Employee/3");
            response.EnsureSuccessStatusCode();

            // Verificar el código de estado
            Assert.True(HttpStatusCode.NoContent == response.StatusCode, "La eliminación del objeto no fue exitosa");
        }
    }
}
