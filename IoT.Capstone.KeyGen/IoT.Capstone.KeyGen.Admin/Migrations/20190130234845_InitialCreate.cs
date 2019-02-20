using Microsoft.EntityFrameworkCore.Migrations;

namespace IoT.Capstone.KeyGen.Admin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdxUsers",
                columns: table => new
                {
                    Uid = table.Column<int>(nullable: false),
                    EdxId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdxUsers", x => x.Uid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdxUsers_EdxId",
                table: "EdxUsers",
                column: "EdxId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdxUsers");
        }
    }
}
