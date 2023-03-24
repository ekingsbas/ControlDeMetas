using ControlDeMetas.Client.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;
using System.Diagnostics.Metrics;
using System.Threading;

namespace ControlDeMetas.Client.Pages
{
    public partial class TareaList : ComponentBase
    {
        SfGrid<Tarea> Grid;

        [Inject]
        public TareaClientService _tareaService { get; set; }

        [Inject]
        public MetaClientService _metaService { get; set; }

        [Parameter]
        public long ? MetaId { get; set; } = null;

        string[] pagerDropdown = new string[] { "Todas", "5", "10", "15", "20" };
        private List<Tarea> Tareas = new List<Tarea>();
        private Meta MetaSelected= new Meta();
        private Tarea tareaSeleccionada = new Tarea();
        private long? selectedTareaId;

        private bool Visibility { get; set; } = false;
        private bool IsVisible { get; set; } = false;

        private string NombreTarea;

        SfTextBox TareaTextboxObj;


        public TareaList()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            //Tareas =  await _tareaService.GetAll();

            await LoadList();
            //await Refresh();
        }

        private async Task LoadList()
        {
            if (MetaId != null)
            {
                MetaSelected = await _metaService.GetById((long)MetaId);
                Tareas = await _tareaService.GetAllById((long)MetaId);
            }
            else
                Tareas = new List<Tarea>();
        }

        public async Task RowSelectingHandler(RowSelectingEventArgs<Tarea> args)
        {
            await Grid.ClearSelectionAsync();   //clear selection  
        }

        public async Task Refresh() 
        {
            await LoadList();
            StateHasChanged();
            
        }

        private void DialogOpen(Object args)
        {

        }
        private void DialogClose(Object args)
        {

        }
        private void OnBtnNuevaClick()
        {
            this.tareaSeleccionada = new Tarea();
            this.Visibility = true;
        }

        private async void OnBtnEditarClick()
        {
            var selectedRecords = await Grid.GetSelectedRecordsAsync();

            if (selectedRecords != null)
            {
                tareaSeleccionada = selectedRecords.FirstOrDefault();
                if (tareaSeleccionada != null)
                {
                    NombreTarea = tareaSeleccionada.Nombre;
                    this.Visibility = true;
                }

                
            }

            
        }

        private async void OnBtnCompletarClick()
        {

        }

        private async void OnBtnEliminarClick()
        {

        }

        private async void AceptarClick()
        {
            if (tareaSeleccionada.Id == 0)
            {
                if (this.TareaTextboxObj.Value != "")
                {
                    NombreTarea = this.TareaTextboxObj.Value;
                    await GuardarTarea(NombreTarea);

                }

            }
            else
            {
                NombreTarea = this.TareaTextboxObj.Value;

                EditTarea(NombreTarea);
            }


            await LoadList();
            this.Visibility = false;
        }

        private void CancelarClick()
        {
            this.Visibility = false;
        }

        private async void DeleteOkClick()
        {
            if (selectedTareaId != null)
            {
                await DeleteTarea();
                
            }


            await LoadList();
            this.IsVisible = false;
        }

        private void DeleteCancelClick()
        {
            this.IsVisible = false;
        }

        private async Task GuardarTarea(string nombre)
        {
            var nuevaTarea = new Tarea
            {
                Nombre = nombre,
                IdMeta = MetaSelected.Id
            };

            await _tareaService.Add(nuevaTarea);
        }

        private async void EditTarea(string nombre)
        {
            var selectedRecords = await Grid.GetSelectedRecordsAsync();

            if (selectedRecords != null)
            {
                foreach (var tarea in selectedRecords)
                    await _tareaService.Update(tarea.Id, new Tarea { Nombre = nombre });

                Tareas = await _tareaService.GetAll();
            }

            

        }

        private async void CompletarTarea()
        {
            var selectedRecords = await Grid.GetSelectedRecordsAsync();

            if (selectedRecords != null)
            {
                foreach (var tarea in selectedRecords)
                    await _tareaService.Update(tarea.Id, new Tarea { Estatus = ControlDeMetas.Shared.Enums.EstatusTarea.Completada });

                Tareas = await _tareaService.GetAll();
            }

            
            Tareas = await _tareaService.GetAll();

        }

        private async Task DeleteTarea()
        {
            var selectedRecords = await Grid.GetSelectedRecordsAsync();

            if (selectedRecords != null)
            {
                foreach (var tarea in selectedRecords)
                    await _tareaService.Delete(tarea.Id);

                Tareas = await _tareaService.GetAll();
            }


        }
    }
}
