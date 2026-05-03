
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tareas.Enumeradores;
namespace Tareas.Entidades
{
    //Melchor Gabriel Lopez Castro

    [Table("Tarea")]
    public class TareaEntity
    {
        [Key] public int IdTarea { get; set; }
        [Required, StringLength(60)] public string Nombre { get; set; } = string.Empty;
        [Required] public string Descripcion { get; set; } = string.Empty;
        [Required] public DateTime Fecha { get; set; }
        [Required] public DateTime FechaCompromiso { get; set; }
        [Required] public EstadoTareaEnum EstadoTarea { get; set; } = EstadoTareaEnum.Pendiente;
        [Required] public int IdEmpleado { get; set; }
        [Required] public int IdProyecto { get; set; }
        public bool EstaActivo { get; set; }
    }
}
