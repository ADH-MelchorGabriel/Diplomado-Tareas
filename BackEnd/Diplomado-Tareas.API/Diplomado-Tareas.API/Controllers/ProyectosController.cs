using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.Contextos;
using Tareas.Dtos;
using Tareas.Entidades;

namespace Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {

        private readonly DataContext _context;

        public ProyectosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await _context.Proyectos
                    .Where(x=> x.EstaActivo)
                    .Select(x=> new ProyectoGetDto(x))
                    .ToListAsync();

                if (lista == null || lista.Count == 0)
                    return NoContent();

                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            } 
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ProyectoSetDto newObj)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var obj = new ProyectoEntity(newObj);

                await _context.Proyectos.AddAsync(obj);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Guardar), new { id = obj.IdProyecto }, obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
