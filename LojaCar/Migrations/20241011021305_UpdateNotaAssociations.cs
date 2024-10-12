using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaCar.Migrations
{
    public partial class UpdateNotaAssociations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Carro_CarroId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Cliente_CompradorId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Vendedor_VendedorId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_CompradorId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "CompradorId",
                table: "Nota");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorId",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_ClienteId",
                table: "Nota",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Carro_CarroId",
                table: "Nota",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Cliente_ClienteId",
                table: "Nota",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Vendedor_VendedorId",
                table: "Nota",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Carro_CarroId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Cliente_ClienteId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Vendedor_VendedorId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_ClienteId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Nota");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorId",
                table: "Nota",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "Nota",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompradorId",
                table: "Nota",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_CompradorId",
                table: "Nota",
                column: "CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Carro_CarroId",
                table: "Nota",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Cliente_CompradorId",
                table: "Nota",
                column: "CompradorId",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Vendedor_VendedorId",
                table: "Nota",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id");
        }
    }
}
