using Microsoft.EntityFrameworkCore.Migrations;

namespace NoviProjekat.Data.Migrations
{
    public partial class MigracijaNova2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Nabavka");

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "NabavkaStavke",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "NabavkaStavke");

            migrationBuilder.AddColumn<float>(
                name: "Kolicina",
                table: "Nabavka",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
