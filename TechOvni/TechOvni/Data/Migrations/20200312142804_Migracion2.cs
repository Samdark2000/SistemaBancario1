using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechOvni.Data.Migrations
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
                    NumeroCuenta = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TCliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "_Ttarjeta",
                columns: table => new
                {
                    TarjetaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Tarjeta = table.Column<int>(nullable: false),
                    DateOuverture = table.Column<DateTime>(nullable: false),
                    CVV = table.Column<int>(nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ttarjeta", x => x.TarjetaID);
                });

            migrationBuilder.CreateTable(
                name: "_TCuenta",
                columns: table => new
                {
                    CuentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(nullable: false),
                    TarjetaID = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK__TCuenta__Ttarjeta_TarjetaID",
                        column: x => x.TarjetaID,
                        principalTable: "_Ttarjeta",
                        principalColumn: "TarjetaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__TCuenta_ClienteID",
                table: "_TCuenta",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX__TCuenta_TarjetaID",
                table: "_TCuenta",
                column: "TarjetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_TCuenta");

            migrationBuilder.DropTable(
                name: "_TCliente");

            migrationBuilder.DropTable(
                name: "_Ttarjeta");
        }
    }
}
