using Microsoft.EntityFrameworkCore.Migrations;

namespace Techh_Onvi.Data.Migrations
{
    public partial class Migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_TCliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TCliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "_TCuenta",
                columns: table => new
                {
                    CuentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Cuenta = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TCuenta", x => x.CuentaID);
                    table.ForeignKey(
                        name: "FK__TCuenta__TCliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "_TCliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__TCuenta_ClienteID",
                table: "_TCuenta",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_TCuenta");

            migrationBuilder.DropTable(
                name: "_TCliente");
        }
    }
}
