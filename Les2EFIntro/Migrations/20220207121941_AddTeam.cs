using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Les2EFIntro.Migrations
{
    public partial class AddTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Group", "Title" },
                values: new object[,]
                {
                    { 201, "Groep-1", "You snooze, you loose!" },
                    { 202, "Groep-2", "Nachos" },
                    { 203, "Groep-3", "3 front-end devs + 1 back-end dev" },
                    { 204, "Groep-4", "Cinavas" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "TeamId" },
                values: new object[] { 1001, "henk@breda.nl", "Henk", 201 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "TeamId" },
                values: new object[] { 1002, "loes@avans.nl", "Loes", 201 });

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Members_TeamId",
                table: "Members");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Members");
        }
    }
}
