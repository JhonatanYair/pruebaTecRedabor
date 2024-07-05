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
    public class TestUpdateEmployee : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestUpdateEmployee(CustomWebApplicationFactory<Program> factory)
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

            responseEmployee.Name = "Usuario Editado";

            // Convertir el objeto a JSON
            var json = JsonConvert.SerializeObject(responseEmployee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la petición POST
            var responseUpdate = await _client.PutAsync($"{TestApi.urlEndpoint}/Status/{responseEmployee.Id}", content);

            responseUpdate.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.OK == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBodyUpdate = await responseUpdate.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            EmployeeDto responseEmployeeUpdate = JsonConvert.DeserializeObject<EmployeeDto>(responseBodyUpdate);

            Assert.True(responseEmployeeUpdate != null, "Objeto vacio");
            Assert.True(responseEmployeeUpdate.Name == responseEmployee.Name, "El objeto no fue editado");

        }
    }
}
