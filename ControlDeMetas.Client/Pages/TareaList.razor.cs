using ControlDeMetas.Client.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;


namespace ControlDeMetas.Client.Pages
{
    public partial class TareaList : ComponentBase
    {
        SfGrid<Tarea> Grid;

        [Inject]
        public TareaClientService _tareaService { get; set; }

        [Parameter]
        public long ? MetaId { get; set; } = null;

        string[] pagerDropdown = new string[] { "Todas", "5", "10", "15", "20" };
        private List<Tarea> Tareas = new List<Tarea>();
        private Meta MetaSelected= new Meta();

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

    }
}
