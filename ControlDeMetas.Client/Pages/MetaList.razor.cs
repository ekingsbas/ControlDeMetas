using ControlDeMetas.Client.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;


namespace ControlDeMetas.Client.Pages
{
    public partial class MetaList : ComponentBase
    {
        private readonly MetaService _metaService;
        //private readonly HttpClient _httpClient;
        //private readonly NavigationManager _navigationManager;

        //public MetaList(MetaService metaService, NavigationManager navigationManager)
        //{
        //    _metaService = metaService;
        //    _navigationManager = navigationManager;
        //}

        //public MetaService _metaService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        public HttpClient _httpClient { get; set; }

        public MetaList()
        {
            _metaService = new MetaService(_httpClient);

        }

        private List<Meta> Metas;

        protected override async Task OnInitializedAsync()
        {
            Metas = await _metaService.GetAll();
        }

        private void EditMeta(int id)
        {
            _navigationManager.NavigateTo($"/meta/edit/{id}");
        }

        private async void DeleteMeta(int id)
        {
            //if (await JS.InvokeAsync<bool>("confirm", $"¿Estás seguro que deseas eliminar la meta con Id {id}?"))
            //{
            //    await _metaService.Delete(id);
            //    Metas = await _metaService.GetAll();
            //}
        }
    }
}
