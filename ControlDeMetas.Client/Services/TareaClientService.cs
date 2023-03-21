using ControlDeMetas.Shared.Entities;
using System.Net.Http.Json;

namespace ControlDeMetas.Client.Services
{
    public class TareaClientService
    {
        private readonly HttpClient _httpClient;


        public TareaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tarea>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Tarea>>("api/tareas");
        }

        public async Task<List<Tarea>> GetAllById(long tareaId)
        {
            return await _httpClient.GetFromJsonAsync<List<Tarea>>($"api/Tareas/byid/{tareaId}");
        }

        public async Task<Tarea> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");
        }

        public async Task Add(Tarea tarea)
        {
            await _httpClient.PostAsJsonAsync("api/tareas", tarea);
        }

        public async Task Update(int id, Tarea tarea)
        {
            await _httpClient.PutAsJsonAsync($"api/tareas/{id}", tarea);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/tareas/{id}");
        }
    }
}
