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
    public class TestCreateEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestCreateEmployee(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            // Preparar el objeto a enviar
            var newItem = new EmployeeDto
            {
                Name = "Empleado Nuevo",
                Email = "empleado@gmail.com",
                Password = "pass12345",
                Fax = "Fax new",
                Telephone = "300000000",
                CompanyId = 1,
                StatusId = 1,
                RoleId = 1,
                PortalId = 1
            };

            // Convertir el objeto a JSON
            var json = JsonConvert.SerializeObject(newItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la petición POST
            var response = await _client.PostAsync($"{TestApi.urlEndpoint}/Employee", content);

            response.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.Created == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            EmployeeDto responseEmployee = JsonConvert.DeserializeObject<EmployeeDto>(responseBody);

            Assert.True(responseEmployee != null, "Objeto vacio");

        }
    }
}
