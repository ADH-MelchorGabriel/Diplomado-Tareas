using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tareas.Entidades
{
    [Table("Empleado")]
    public class EmpleadosEntity
    {
        [Key]public int IdEmpleado { get; set; }
        [Required, StringLength(90)] public string Nombre { get; set; } = string.Empty;
        [StringLength(10)]public string? Telefono { get; set; }
        [StringLength(250)]public string? Correo { get; set; }
        public bool EstaActivo { get; set; }
    }
}
