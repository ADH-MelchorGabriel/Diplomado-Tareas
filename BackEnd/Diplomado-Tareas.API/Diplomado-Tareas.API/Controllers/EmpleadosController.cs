using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using Tareas.Contextos;
using Tareas.Dtos;
using Tareas.Entidades;

namespace Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmpleadosController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await _context.Empleados
                    .Where(x => x.EstaActivo)
                    .Select(x => _mapper.Map<EmpleadoGetDto>(x))
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
                var obj = await _context.Empleados.Where(x=> x.EstaActivo && x.IdEmpleado==id).FirstOrDefaultAsync();
                if (obj == null)
                    return NotFound("Empleado no encontrado");

                return Ok(_mapper.Map<EmpleadoGetDto>(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(EmpleadoSetDto newObj)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var obj = _mapper.Map<EmpleadosEntity>(newObj);

                await _context.Empleados.AddAsync(obj);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Buscar), new { id = obj.IdEmpleado }, _mapper.Map<EmpleadoGetDto>(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Modificar(int id, EmpleadoSetDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalid");

                var Empleado = await _context.Empleados.Where(x=> x.EstaActivo && x.IdEmpleado==id).FirstOrDefaultAsync();

                if (Empleado == null)
                    return NotFound("Empleado no encontrado");

                _mapper.Map(obj, Empleado);


                _context.Empleados.Update(Empleado);
                await _context.SaveChangesAsync();

                return Ok(_mapper.Map<EmpleadoGetDto>(Empleado));


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
                var Empleado = await _context.Empleados.Where(x=> x.EstaActivo && x.IdEmpleado==id).FirstOrDefaultAsync();

                if (Empleado == null)
                    return NotFound("Empleado no encontrado");

                //_context.Empleados.Remove(Empleado);

                Empleado.EstaActivo = false;

                _context.Empleados.Update(Empleado);
                await _context.SaveChangesAsync();

                return Ok(_mapper.Map<EmpleadoGetDto>(Empleado));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
