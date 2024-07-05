using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitPruebaRedarbor.Shared;
using PruebaRedarbor;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Newtonsoft.Json;
using PruebaRedarbor.Application.DTOs;
using Microsoft.AspNetCore.Connections;

namespace TestUnitPruebaRedarbor.CodeTests.Status
{
 
    public class TestGetAllStatus : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestGetAllStatus(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            var response = await _client.GetAsync($"{TestApi.urlEndpoint}/Status");
            response.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.OK == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            List<StatusDto> listStatus = JsonConvert.DeserializeObject<List<StatusDto>>(responseBody);

            Assert.True(listStatus.Count >0, "Objeto vacio");

        }
    }

}
