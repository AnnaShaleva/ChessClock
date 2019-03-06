using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessClock.DAL.Migrations
{
    public partial class CurrentPlayerNullableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentPlayerId",
                table: "Sessions",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentPlayerId",
                table: "Sessions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
