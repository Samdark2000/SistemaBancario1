using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Techh_Onvi.Data.Migrations
{
    public partial class MigrationTrasanction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero_Cuenta",
                table: "_TCuenta",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "_Trasanction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(nullable: true),
                    Beneficiario = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    SWIFTCode = table.Column<string>(nullable: true),
                    Monto = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trasanction", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Trasanction");

            migrationBuilder.AlterColumn<string>(
                name: "Numero_Cuenta",
                table: "_TCuenta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
