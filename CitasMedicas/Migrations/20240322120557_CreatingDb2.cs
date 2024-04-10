using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicModelPacientModel",
                columns: table => new
                {
                    medicosid = table.Column<long>(type: "bigint", nullable: false),
                    pacientesid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicModelPacientModel", x => new { x.medicosid, x.pacientesid });
                    table.ForeignKey(
                        name: "FK_MedicModelPacientModel_Usuario_medicosid",
                        column: x => x.medicosid,
                        principalTable: "Usuario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MedicModelPacientModel_Usuario_pacientesid",
                        column: x => x.pacientesid,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "id", "Discriminator", "apellidos", "clave", "nombre", "numColegiado", "usuario" },
                values: new object[] { -2L, "MedicModel", "Pujante", "1234", "Mario", "12345A", "MPujante" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicModelPacientModel_pacientesid",
                table: "MedicModelPacientModel",
                column: "pacientesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicModelPacientModel");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: -2L);
        }
    }
}
