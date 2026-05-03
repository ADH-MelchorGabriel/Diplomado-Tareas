using Microsoft.EntityFrameworkCore;
using Tareas.Entidades;

namespace Tareas.Contextos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TareaEntity> Tareas { get; set; }
        public DbSet<EmpleadosEntity> Empleados{ get; set; }
        public DbSet<ProyectoEntity> Proyectos{ get; set; }
    }
}
