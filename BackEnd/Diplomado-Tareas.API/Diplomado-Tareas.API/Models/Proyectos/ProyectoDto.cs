using System.ComponentModel.DataAnnotations;

namespace Tareas.Dtos
{
    public class ProyectoSetDto
    {
        [Required, StringLength(120)] public string Nombre { get; set; } = string.Empty;
    }

    public class ProyectoGetDto
    {

        [Required] public int IdProyecto { get; set; }
        [Required, StringLength(120)] public string Nombre { get; set; } = string.Empty;

    }
}
