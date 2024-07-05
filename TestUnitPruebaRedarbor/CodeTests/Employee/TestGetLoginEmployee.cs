using Newtonsoft.Json;
using PruebaRedarbor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestUnitPruebaRedarbor.Shared;

namespace TestUnitPruebaRedarbor.CodeTests.Employee
{
    public class TestGetLoginEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestGetLoginEmployee(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {

            var newItem = new EmployeeDto
            {
                Email = "usuario1@gmail.com",
                Password = "enter12345"
            };

            // Convertir el objeto a JSON
            var json = JsonConvert.SerializeObject(newItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la petición POST
            var response = await _client.PostAsync($"{TestApi.urlEndpoint}/Employee/login", content);

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
