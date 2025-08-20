using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraAulaApis.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Todos");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Todos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Todos",
                type: "INTEGER",
                nullable: true);
        }
    }
}
