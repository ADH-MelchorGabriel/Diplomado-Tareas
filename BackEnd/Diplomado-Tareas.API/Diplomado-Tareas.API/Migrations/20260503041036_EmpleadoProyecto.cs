using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomado_Tareas.API.Migrations
{
    public partial class EmpleadoProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.IdProyecto);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_IdEmpleado",
                table: "Tarea",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_IdProyecto",
                table: "Tarea",
                column: "IdProyecto");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Empleado_IdEmpleado",
                table: "Tarea",
                column: "IdEmpleado",
                principalTable: "Empleado",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Proyecto_IdProyecto",
                table: "Tarea",
                column: "IdProyecto",
                principalTable: "Proyecto",
                principalColumn: "IdProyecto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Empleado_IdEmpleado",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Proyecto_IdProyecto",
                table: "Tarea");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_IdEmpleado",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_IdProyecto",
                table: "Tarea");
        }
    }
}
