using ControlDeMetas.BLL.Contracts;
using ControlDeMetas.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeMetas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetasController : ControllerBase
    {
        private readonly IBaseService<Meta> _metaService;
        private readonly ILogger<Meta> _logger;

        public MetasController(ILogger<Meta> logger, IBaseService<Meta> metaService)
        {
            _logger = logger;
            _metaService = metaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var metas = await _metaService.GetAllAsync();
            return Ok(metas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meta = await _metaService.GetByIdAsync(id);

            if (meta == null)
            {
                return NotFound();
            }

            return Ok(meta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Meta meta)
        {
            var createdMeta = await _metaService.AddAsync(meta);
            return CreatedAtAction(nameof(GetById), new { id = createdMeta.Id }, createdMeta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Meta meta)
        {
            if (id != meta.Id)
            {
                return BadRequest();
            }

            await _metaService.UpdateAsync(meta);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var meta = await _metaService.GetByIdAsync(id);

            if (meta == null)
            {
                return NotFound();
            }

            await _metaService.DeleteAsync(id);

            return NoContent();
        }
    }
}
