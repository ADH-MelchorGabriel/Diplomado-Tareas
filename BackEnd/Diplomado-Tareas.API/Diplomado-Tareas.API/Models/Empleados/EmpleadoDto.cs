using System.ComponentModel.DataAnnotations;

namespace Tareas.Dtos

{
    public class EmpleadoSetDto
    {
        [Required, StringLength(90)] public string Nombre { get; set; } = string.Empty;
        [StringLength(10)] public string? Telefono { get; set; }
        [StringLength(250)] public string? Correo { get; set; }
    }
    public class EmpleadoGetDto
    {
        [Key] public int IdEmpleado { get; set; }
        [Required, StringLength(90)] public string Nombre { get; set; } = string.Empty;
        [StringLength(10)] public string? Telefono { get; set; }
        [StringLength(250)] public string? Correo { get; set; }
    }
}
