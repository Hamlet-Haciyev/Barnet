using Microsoft.EntityFrameworkCore.Migrations;

namespace Barnet.Migrations
{
    public partial class cretProjectSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "serv_Project_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serv_Project_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Serv_Project_Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Projects_serv_Project_Categories_Serv_Project_Category_Id",
                        column: x => x.Serv_Project_Category_Id,
                        principalTable: "serv_Project_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Projects_Serv_Project_Category_Id",
                table: "Service_Projects",
                column: "Serv_Project_Category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service_Projects");

            migrationBuilder.DropTable(
                name: "serv_Project_Categories");
        }
    }
}
