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

        public async Task<Tarea> GetById(long id)
        {
            return await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");
        }

        public async Task Add(Tarea tarea)
        {
            await _httpClient.PostAsJsonAsync("api/tareas", tarea);
        }

        public async Task Update(long id, Tarea tarea)
        {
            var tareaSeleccionada = await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");

            if (tareaSeleccionada != null )
            {
                if (tareaSeleccionada.Nombre != tarea.Nombre && tarea.Nombre != null)
                    tarea.Nombre = tarea.Nombre;

                if (tareaSeleccionada.Estatus != tarea.Estatus )
                    tarea.Estatus = tarea.Estatus;


                await _httpClient.PutAsJsonAsync($"api/tareas/{id}", tareaSeleccionada);
            }
            
        }

        public async Task Complete(long id, Tarea tarea)
        {
            var tareaSeleccionada = await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");

            

            if (tareaSeleccionada != null)
            {
                
                    tarea.Estatus = ControlDeMetas.Shared.Enums.EstatusTarea.Completada;


                await _httpClient.PutAsJsonAsync($"api/tareas/{id}", tareaSeleccionada);
            }

            var metaSelecionada = await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{id}");

            if (metaSelecionada != null)
            {

                tarea.Estatus = ControlDeMetas.Shared.Enums.EstatusTarea.Completada;


                await _httpClient.PutAsJsonAsync($"api/tareas/{id}", tareaSeleccionada);
            }

        }

        public async Task Delete(long id)
        {
            await _httpClient.DeleteAsync($"api/tareas/{id}");
        }
    }
}
