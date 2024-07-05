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
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace TestUnitPruebaRedarbor.CodeTests.Employee
{
 
    public class TestGetAllEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestGetAllEmployee(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TestApi.token);

            var response = await _client.GetAsync($"{TestApi.urlEndpoint}/Employee");
            response.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.OK == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            List<EmployeeDto> listEmployee = JsonConvert.DeserializeObject<List<EmployeeDto>>(responseBody);

            Assert.True(listEmployee.Count >0, "Objeto vacio");

        }
    }

}
