using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tareas.Dtos;

namespace Tareas.Entidades
{
    [Table("Proyecto")]
    public class ProyectoEntity
    {

        [Key] public int IdProyecto { get; set; }
        [Required,StringLength(120)]public string Nombre { get; set; }=string.Empty;    
        public bool EstaActivo{ get; set; }
    }
}
