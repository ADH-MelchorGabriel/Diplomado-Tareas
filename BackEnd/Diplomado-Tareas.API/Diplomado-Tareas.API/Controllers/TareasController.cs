using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.Contextos;
using Tareas.Dtos;
using Tareas.Entidades;

namespace Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TareasController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TareasController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
       
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await _context.Tareas
                    .Include(x=> x.Empleado)
                    .Include(x=> x.Proyecto)
                    .Where(x => x.EstaActivo)
                    .Select(x => _mapper.Map<TareaGetDto>(x))
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


        [HttpGet("id")]
        public async Task<IActionResult> Buscar(int id)
        {
            try
            {
                var obj = await _context.Tareas
                    .Include(c=>c.Empleado)
                    .Include(c => c.Proyecto)
                    .Where(z=> z.EstaActivo && z.IdTarea==id).FirstOrDefaultAsync();
                if (obj == null)
                    return NotFound("Empleado no encontrado");

                return Ok(_mapper.Map<TareaGetDto>(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost]
        public async Task<IActionResult> Guardar(TareaSetDto newObj)
        {

            try
            {
                if (newObj.IdProyecto==0 || newObj.IdEmpleado==0)
                    return BadRequest("Debe seleccionar un proyecto y un empleado");


                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var obj = _mapper.Map<TareaEntity>(newObj);

                await _context.Tareas.AddAsync(obj);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Guardar), new { id = obj.IdEmpleado }, _mapper.Map<TareaGetDto>(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Modificar(int id, TareaSetDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalid");

                var Tarea = await _context.Tareas.Where(z => z.EstaActivo && z.IdTarea == id).FirstOrDefaultAsync();

                if (Tarea == null)
                    return NotFound("Proyecto no encontrado");


                _mapper.Map(obj, Tarea);

                _context.Tareas.Update(Tarea);
                await _context.SaveChangesAsync();

                return Ok(_mapper.Map<TareaGetDto>(Tarea));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int id)
        {
            try
            {
                var Tarea = await _context.Tareas.Where(x => x.EstaActivo && x.IdTarea == id).FirstOrDefaultAsync();

                if (Tarea == null)
                    return NotFound("Empleado no encontrado");

                //_context.Empleados.Remove(Empleado);

                Tarea.EstaActivo = false;

                _context.Tareas.Update(Tarea);
                await _context.SaveChangesAsync();

                return Ok(_mapper.Map<TareaGetDto>(Tarea));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
