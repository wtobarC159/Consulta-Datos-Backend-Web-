using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Rest_Para_Consulta_de_Datos.Migrations
{
    /// <inheritdoc />
    public partial class BaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contribucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadMiembros = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoExistencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Miembros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antiguedad = table.Column<int>(type: "int", nullable: false),
                    CI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contribucion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContribucionMiembro",
                columns: table => new
                {
                    ContribucionesId = table.Column<int>(type: "int", nullable: false),
                    MiembrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContribucionMiembro", x => new { x.ContribucionesId, x.MiembrosId });
                    table.ForeignKey(
                        name: "FK_ContribucionMiembro_Contribuciones_ContribucionesId",
                        column: x => x.ContribucionesId,
                        principalTable: "Contribuciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContribucionMiembro_Miembros_MiembrosId",
                        column: x => x.MiembrosId,
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    MiembroID = table.Column<int>(type: "int", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.MiembroID, x.DepartamentoID });
                    table.ForeignKey(
                        name: "FK_Portfolios_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Miembros_MiembroID",
                        column: x => x.MiembroID,
                        principalTable: "Miembros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContribucionMiembro_MiembrosId",
                table: "ContribucionMiembro",
                column: "MiembrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_DepartamentoID",
                table: "Portfolios",
                column: "DepartamentoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContribucionMiembro");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Contribuciones");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Miembros");
        }
    }
}
