using ControlDeMetas.Shared.Entities;
using System.Net.Http.Json;
using System.Threading;

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

            var metaSelecionada = await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{tarea.IdMeta}");
            Console.WriteLine("meta: " + metaSelecionada.ToString());

            if (metaSelecionada != null)
            {

                metaSelecionada.TotalTareas = metaSelecionada.TotalTareas + 1;
                metaSelecionada.Cumplimiento = ((decimal)metaSelecionada.TareasCompletadas / (decimal)metaSelecionada.TotalTareas) * (decimal)100;

                var response = await _httpClient.PutAsJsonAsync($"api/metas/{tarea.IdMeta}", metaSelecionada);

                Console.WriteLine($"Response: {response}");
            }
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

                tareaSeleccionada.Estatus = ControlDeMetas.Shared.Enums.EstatusTarea.Completada;


                await _httpClient.PutAsJsonAsync($"api/tareas/completar/{id}", tareaSeleccionada);

                var metaSelecionada = await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{tareaSeleccionada.IdMeta}");

                if (metaSelecionada != null)
                {

                    metaSelecionada.TareasCompletadas = metaSelecionada.TareasCompletadas + 1;
                    metaSelecionada.Cumplimiento = ((decimal)metaSelecionada.TareasCompletadas / (decimal)metaSelecionada.TotalTareas) * (decimal)100;

                    await _httpClient.PutAsJsonAsync($"api/metas/{metaSelecionada.Id}", metaSelecionada);
                }
            }

            

        }

        public async Task DeleteOnly(long id)
        {
            await _httpClient.DeleteAsync($"api/tareas/{id}");
        }

        public async Task Delete(long id)
        {
            try
            {
                var tareaSeleccionada = await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");



                if (tareaSeleccionada != null)
                {
                    var metaSelecionada = await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{tareaSeleccionada.IdMeta}");

                    if (metaSelecionada != null)
                    {

                        metaSelecionada.TotalTareas = metaSelecionada.TotalTareas - 1;

                        if (tareaSeleccionada.Estatus == ControlDeMetas.Shared.Enums.EstatusTarea.Completada)
                        {
                            metaSelecionada.TareasCompletadas = metaSelecionada.TareasCompletadas - 1;
                        }

                        metaSelecionada.Cumplimiento = ((decimal)metaSelecionada.TareasCompletadas / (decimal)metaSelecionada.TotalTareas) * (decimal)100;

                        await _httpClient.PutAsJsonAsync($"api/metas/{tareaSeleccionada.IdMeta}", metaSelecionada);
                    }

                    await _httpClient.DeleteAsync($"api/tareas/{id}");


                }
            }
            catch
            {

            }

            
        }
    }
}
