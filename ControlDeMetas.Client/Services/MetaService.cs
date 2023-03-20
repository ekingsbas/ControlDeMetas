using ControlDeMetas.Shared.Entities;
using System.Net.Http.Json;

namespace ControlDeMetas.Client.Services
{
    public class MetaService
    {
        private readonly HttpClient _httpClient;

        public MetaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Meta>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Meta>>("api/meta");
        }

        public async Task<Meta> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Meta>($"api/meta/{id}");
        }

        public async Task Add(Meta meta)
        {
            await _httpClient.PostAsJsonAsync("api/meta", meta);
        }

        public async Task Update(int id, Meta meta)
        {
            await _httpClient.PutAsJsonAsync($"api/meta/{id}", meta);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/meta/{id}");
        }
    }
}
