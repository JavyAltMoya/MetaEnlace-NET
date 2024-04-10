using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_MedicModelId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_PacientModelId",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "PacientModelId",
                table: "Citas",
                newName: "paciente_id");

            migrationBuilder.RenameColumn(
                name: "MedicModelId",
                table: "Citas",
                newName: "medico_id");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_PacientModelId",
                table: "Citas",
                newName: "IX_Citas_paciente_id");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_MedicModelId",
                table: "Citas",
                newName: "IX_Citas_medico_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_medico_id",
                table: "Citas",
                column: "medico_id",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_paciente_id",
                table: "Citas",
                column: "paciente_id",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_medico_id",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuario_paciente_id",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "paciente_id",
                table: "Citas",
                newName: "PacientModelId");

            migrationBuilder.RenameColumn(
                name: "medico_id",
                table: "Citas",
                newName: "MedicModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_paciente_id",
                table: "Citas",
                newName: "IX_Citas_PacientModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_medico_id",
                table: "Citas",
                newName: "IX_Citas_MedicModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_MedicModelId",
                table: "Citas",
                column: "MedicModelId",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuario_PacientModelId",
                table: "Citas",
                column: "PacientModelId",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
