using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartamentoJusticia.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rango = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AniosExperiencia = table.Column<int>(type: "int", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tribunales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JuezAsignado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadSalas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribunales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasosJudiciales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCaso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCaso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDelito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasosJudiciales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasosJudiciales_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audiencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipoAudiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TribunalId = table.Column<int>(type: "int", nullable: false),
                    CasoJudicialId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audiencias_CasosJudiciales_CasoJudicialId",
                        column: x => x.CasoJudicialId,
                        principalTable: "CasosJudiciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audiencias_Tribunales_TribunalId",
                        column: x => x.TribunalId,
                        principalTable: "Tribunales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEvidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LugarHallazgo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecoleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CasoJudicialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidencias_CasosJudiciales_CasoJudicialId",
                        column: x => x.CasoJudicialId,
                        principalTable: "CasosJudiciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreOperativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEjecucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOperativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agente1Id = table.Column<int>(type: "int", nullable: false),
                    Agente2Id = table.Column<int>(type: "int", nullable: false),
                    Agente3Id = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasoJudicialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operativos_Agentes_Agente1Id",
                        column: x => x.Agente1Id,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operativos_Agentes_Agente2Id",
                        column: x => x.Agente2Id,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operativos_Agentes_Agente3Id",
                        column: x => x.Agente3Id,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operativos_CasosJudiciales_CasoJudicialId",
                        column: x => x.CasoJudicialId,
                        principalTable: "CasosJudiciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sospechosos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelPeligrosidad = table.Column<int>(type: "int", nullable: false),
                    EstadoLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasoJudicialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sospechosos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sospechosos_CasosJudiciales_CasoJudicialId",
                        column: x => x.CasoJudicialId,
                        principalTable: "CasosJudiciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audiencias_CasoJudicialId",
                table: "Audiencias",
                column: "CasoJudicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Audiencias_TribunalId",
                table: "Audiencias",
                column: "TribunalId");

            migrationBuilder.CreateIndex(
                name: "IX_CasosJudiciales_AgenteId",
                table: "CasosJudiciales",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencias_CasoJudicialId",
                table: "Evidencias",
                column: "CasoJudicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Agente1Id",
                table: "Operativos",
                column: "Agente1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Agente2Id",
                table: "Operativos",
                column: "Agente2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Agente3Id",
                table: "Operativos",
                column: "Agente3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_CasoJudicialId",
                table: "Operativos",
                column: "CasoJudicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Sospechosos_CasoJudicialId",
                table: "Sospechosos",
                column: "CasoJudicialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audiencias");

            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "Evidencias");

            migrationBuilder.DropTable(
                name: "Operativos");

            migrationBuilder.DropTable(
                name: "Sospechosos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tribunales");

            migrationBuilder.DropTable(
                name: "CasosJudiciales");

            migrationBuilder.DropTable(
                name: "Agentes");
        }
    }
}
