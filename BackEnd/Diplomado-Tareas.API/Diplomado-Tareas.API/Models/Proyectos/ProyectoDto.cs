using System.ComponentModel.DataAnnotations;
using Tareas.Entidades;

namespace Tareas.Dtos
{
    public class ProyectoSetDto
    {
        [Required, StringLength(120)] public string Nombre { get; set; } = string.Empty;
    }

    public class ProyectoGetDto
    {

        public ProyectoGetDto( ProyectoEntity entity)
        {
            IdProyecto = entity.IdProyecto;
            Nombre = entity.Nombre;
        }

        [Required] public int IdProyecto { get; set; }
        [Required, StringLength(120)] public string Nombre { get; set; } = string.Empty;

    }
}
