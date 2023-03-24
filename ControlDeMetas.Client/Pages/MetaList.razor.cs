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

        [Inject]
        public TareaClientService _tareaService { get; set; }


        private long? selectedMetaId;

        private TareaList _tareaList;

        private string nombreMeta;

        private Meta metaSeleccionada = new Meta();
        private bool Visibility { get; set; } = false;
        private bool IsVisible { get; set; } = false;

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

        //private void EditMeta(int id)
        //{
        //    _navigationManager.NavigateTo($"/meta/edit/{id}");
        //}

   //     private async void DeleteMeta(int id)
   //     {

   //         //Lista de tareas
   //         var tareas = await _tareaService.GetAllById(id);

   //         if (tareas != null)
   //         {
   //             foreach (var tarea in tareas)
   //                 await _tareaService.Delete(tarea.Id);
   //         }

			//await _metaService.Delete(id);
			//Metas = await _metaService.GetAll();
   //         await _tareaList.Refresh();


   //     }

        private async void EditMeta(long id, string nombre)
        {

            await _metaService.Update(id, new Meta { Nombre = nombre});
            Metas = await _metaService.GetAll();

        }

        private async void MetaEditAtIndex(long i)
		{
            
            metaSeleccionada = await _metaService.GetById(i);

            if (metaSeleccionada != null)
            {
                NombreMeta = metaSeleccionada.Nombre;
                this.Visibility = true;
            }
                
        }

        private async void MetaDeleteAtIndex(long i)
        {
            metaSeleccionada = await _metaService.GetById(i);

            if (metaSeleccionada != null)
            {
                NombreMeta = metaSeleccionada.Nombre;
                this.IsVisible = true;
            }
        }

        private async void MetaClickedAtIndex(long i)
        {
            
            Console.WriteLine($"Meta clicked at index {i}!");
            selectedMetaId = i;

            metaSeleccionada = await _metaService.GetById((long)selectedMetaId);

            if (metaSeleccionada != null)
                nombreMeta = metaSeleccionada.Nombre;

            if (_tareaList != null)
                await _tareaList.Refresh();

        }

        
        private void DialogOpen(Object args)
        {
            
        }
        private void DialogClose(Object args)
        {
            
        }
        private void OnBtnNuevaClick()
        {
            this.metaSeleccionada = new Meta();
            this.Visibility = true;
        }
        private async void AceptarClick()
        {
            if (metaSeleccionada.Id == 0)
            {
                if (this.MetaTextboxObj.Value != "")
                {
                    NombreMeta = this.MetaTextboxObj.Value;
                    await GuardarMeta(NombreMeta);

                }

            }
            else
            {
                NombreMeta = this.MetaTextboxObj.Value;

                EditMeta(metaSeleccionada.Id, NombreMeta);
            }

            
            await CargarMetas();
            this.Visibility = false;
        }

        private void CancelarClick()
        {
            this.Visibility = false;
        }

        private async void DeleteOkClick()
        {
            try
            {
                if (selectedMetaId != null)
                {
                    //Lista de tareas
                    var tareas = await _tareaService.GetAllById((long)selectedMetaId);

                    if (tareas != null)
                    {
                        foreach (var tarea in tareas)
                            await _tareaService.DeleteOnly(tarea.Id);
                    }

                    await _metaService.Delete((long)selectedMetaId);
                    Metas = await _metaService.GetAll();
                    await _tareaList.Refresh();

                    _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
                }


            }
            catch { }
            finally
            {

                await CargarMetas();
                this.IsVisible = false;
            }
            
        }

        private void DeleteCancelClick()
        {
            this.IsVisible = false;
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
