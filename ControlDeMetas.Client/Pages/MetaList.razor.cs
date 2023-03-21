using ControlDeMetas.Client.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using System;


namespace ControlDeMetas.Client.Pages
{
    public partial class MetaList : ComponentBase
    {
        
        [Inject]
        public NavigationManager _navigationManager { get; set; }

       

        [Inject]
        public MetaClientService _metaService { get; set; }


        private long? selectedMetaId;

        private TareaList _tareaList;

        private string nombreMeta;

        private Meta metaSeleccionada = new Meta();

        public MetaList()
        {
            

        }

        private List<Meta> Metas = new List<Meta>();

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

        private async void MetaClickedAtIndex(long i)
        {
            
            Console.WriteLine($"Meta clicked at index {i}!");
            selectedMetaId = i;

            metaSeleccionada = await _metaService.GetById((long)selectedMetaId);

            if (metaSeleccionada != null)
                nombreMeta = metaSeleccionada.Nombre;

            if (_tareaList != null)
                _tareaList.Refresh();

        }
    }
}
