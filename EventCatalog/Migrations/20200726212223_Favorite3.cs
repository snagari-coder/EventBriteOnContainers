using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalog.Migrations
{
    public partial class Favorite3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventUserInfos_Event_UserId",
                table: "EventItems");

            migrationBuilder.DropTable(
                name: "EventUserInfos");

            migrationBuilder.DropIndex(
                name: "IX_EventItems_Event_UserId",
                table: "EventItems");

            migrationBuilder.AlterColumn<string>(
                name: "Event_UserId",
                table: "EventItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Favorite",
                table: "EventItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "EventItems");

            migrationBuilder.AlterColumn<string>(
                name: "Event_UserId",
                table: "EventItems",
                type: "nvarchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventUserInfos",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserInfos", x => x.UserName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_Event_UserId",
                table: "EventItems",
                column: "Event_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventUserInfos_Event_UserId",
                table: "EventItems",
                column: "Event_UserId",
                principalTable: "EventUserInfos",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
