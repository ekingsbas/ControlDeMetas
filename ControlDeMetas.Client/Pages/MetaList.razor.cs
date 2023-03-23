using ControlDeMetas.Client.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Popups;
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
        private bool Visibility { get; set; } = false;

        private string NombreMeta;

        SfTextBox MetaTextboxObj;

        public MetaList()
        {
            

        }

        private List<Meta> Metas = new List<Meta>();

        protected override async Task OnInitializedAsync()
        {
            await CargarMetas();
        }

        private async Task CargarMetas()
		{
            Metas = await _metaService.GetAll();
        }

        private void EditMeta(int id)
        {
            _navigationManager.NavigateTo($"/meta/edit/{id}");
        }

        private async void DeleteMeta(int id)
        {

			await _metaService.Delete(id);
			Metas = await _metaService.GetAll();

		}

        private async void EditMeta(int id, string nombre)
        {

            await _metaService.Update(id, new Meta { Nombre = nombre});
            Metas = await _metaService.GetAll();

        }

        private async void MetaEditAtIndex(long i)
		{

		}

        private async void MetaDeleteAtIndex(long i)
        {

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

        
        private void DialogOpen(Object args)
        {
            
        }
        private void DialogClose(Object args)
        {
            
        }
        private void OnBtnClick()
        {
            this.Visibility = true;
        }
        private async void AceptarClick()
        {
            if (this.MetaTextboxObj.Value != "")
            {
                NombreMeta = this.MetaTextboxObj.Value;
                await GuardarMeta(NombreMeta);
                
            }
            await CargarMetas();
            this.Visibility = false;
        }

        private void CancelarClick()
        {
            this.Visibility = false;
        }

        private async Task GuardarMeta(string nombre)
		{
            var nuevaMeta = new Meta
            {
                Nombre = nombre,

            };

            await _metaService.Add(nuevaMeta);
        }
    }
}
