using ControlDeMetas.BLL.Contracts;
using ControlDeMetas.BLL.Services;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeMetas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly TareaService _tareaService;
        private readonly ILogger<Tarea> _logger;

        public TareasController(ILogger<Tarea> logger, IBaseService<Tarea> tareaService)
        {
            _logger = logger;
            _tareaService = (TareaService)tareaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tareas = await _tareaService.GetAllAsync();
            return Ok(tareas);
        }

        [HttpGet("byid/{id}")]
        public async Task<IActionResult> GetAllById(long id)
        {
            var tareas = await _tareaService.GetTareasByMetaIdAsync(id);
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var tarea = await _tareaService.GetByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tarea tarea)
        {
            var createdTarea = await _tareaService.AddAsync(tarea);
            return CreatedAtAction(nameof(GetById), new { id = createdTarea.Id }, createdTarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            await _tareaService.UpdateAsync(tarea);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarea = await _tareaService.GetByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            await _tareaService.DeleteAsync(id);

            return NoContent();
        }
    }
}
