using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelCarros.Migrations
{
    public partial class CriandoColunaPlacaCarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Carros");
        }
    }
}
