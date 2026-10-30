using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace relacionesMVC_ASP.net.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Vehiculo");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Vehiculo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AnioFundacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_MarcaId",
                table: "Vehiculo",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Marca_MarcaId",
                table: "Vehiculo",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Marca_MarcaId",
                table: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_MarcaId",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Vehiculo");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Vehiculo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
