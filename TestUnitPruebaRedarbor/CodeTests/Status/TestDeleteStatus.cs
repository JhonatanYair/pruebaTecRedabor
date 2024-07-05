using Newtonsoft.Json;
using PruebaRedarbor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestUnitPruebaRedarbor.Shared;

namespace TestUnitPruebaRedarbor.CodeTests.Status
{
    public class TestDeleteStatus : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestDeleteStatus(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            var response = await _client.DeleteAsync($"{TestApi.urlEndpoint}/Status/3");
            response.EnsureSuccessStatusCode();

            // Verificar el código de estado
            Assert.True(HttpStatusCode.NoContent == response.StatusCode, "La eliminación del objeto no fue exitosa");
        }
    }
}
