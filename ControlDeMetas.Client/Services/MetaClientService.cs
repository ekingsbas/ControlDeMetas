using ControlDeMetas.Client.Contracts;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ControlDeMetas.Client.Services
{
    public class MetaClientService: IMetaClientService
    {
        private readonly HttpClient _httpClient;
        

        public MetaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Meta>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Meta>>("api/metas");
        }

        public async Task<Meta> GetById(long id)
        {
            return await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{id}");
        }

        public async Task Add(Meta meta)
        {
            var response = await _httpClient.PostAsJsonAsync("api/metas", meta);
            Console.WriteLine(response);
        }

        public async Task Update(long id, Meta meta)
        {
            var editMeta = await _httpClient.GetFromJsonAsync<Meta>($"api/metas/{id}");
            if (editMeta != null)
			{
                editMeta.Nombre = meta.Nombre;
                var response = await _httpClient.PutAsJsonAsync($"api/metas/{id}", editMeta);
                Console.WriteLine(response);
            }
            
        }

        public async Task Delete(long id)
        {
            await _httpClient.DeleteAsync($"api/metas/{id}");
        }
    }
}
