using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Project.Migrations
{
    public partial class AddRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Menu",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    ChefID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restaurant_Chef_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chef",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Restaurant_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ChefID",
                table: "Restaurant",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MenuID",
                table: "Restaurant",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Menu",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
