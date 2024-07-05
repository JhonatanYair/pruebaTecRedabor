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
    public class TestUpdateStatus : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TestUpdateStatus(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Execute()
        {
            // Preparar el objeto a enviar
            var editItem = new StatusDto
            {
                Id = 2,
                Name = "Editado Estado",
            };

            // Convertir el objeto a JSON
            var json = JsonConvert.SerializeObject(editItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la petición POST
            var response = await _client.PutAsync($"{TestApi.urlEndpoint}/Status/2", content);

            response.EnsureSuccessStatusCode();

            Assert.True(HttpStatusCode.OK == response.StatusCode, "La petición al endpoint no fue exitosa");

            // Leer el contenido de la respuesta como string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar el contenido JSON en una lista de objetos StatusItem
            StatusDto responseStatus = JsonConvert.DeserializeObject<StatusDto>(responseBody);

            Assert.True(responseStatus != null, "Objeto vacio");
            Assert.True(responseStatus.Name == editItem.Name, "El objeto no fue editado");

        }
    }
}
