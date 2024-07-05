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
    public class TestGetByIdEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestGetByIdEmployee(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TestApi.token);

            var response = await _client.GetAsync($"{TestApi.urlEndpoint}/Employee/1");
            response.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.OK == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            EmployeeDto responseEmployee = JsonConvert.DeserializeObject<EmployeeDto>(responseBody);

            Assert.True(responseEmployee != null, "Objeto vacio");

        }
    }
}
