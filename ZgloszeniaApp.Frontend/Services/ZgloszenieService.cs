using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ZgloszeniaApp.Shared.Models;

namespace ZgloszeniaApp.Frontend.Services
{
    public class ZgloszenieService
    {
        private readonly HttpClient _httpClient;

        public ZgloszenieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Zgloszenie>> GetZgloszenia()
        {
            return await _httpClient.GetFromJsonAsync<List<Zgloszenie>>("api/Zgloszenia");
        }

        public async Task<Zgloszenie> AddZgloszenie(Zgloszenie zgloszenie)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Zgloszenia", zgloszenie);
            response.EnsureSuccessStatusCode();

            // Tutaj pobieramy obiekt Zgloszenie z serwera, który ma ID przydzielone przez bazę
            var createdZgloszenie = await response.Content.ReadFromJsonAsync<Zgloszenie>();
            return createdZgloszenie;
        }


        public async Task DeleteZgloszenie(int id)
        {
            await _httpClient.DeleteAsync($"api/Zgloszenia/{id}");
        }
    }
}
