using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseCRUD.Migrations
{
    public partial class createInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cinsiyetler",
                columns: table => new
                {
                    cinsiyetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cinsiyetAdi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinsiyetler", x => x.cinsiyetId);
                });

            migrationBuilder.CreateTable(
                name: "personeller",
                columns: table => new
                {
                    personelNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(nullable: false),
                    soyad = table.Column<string>(nullable: false),
                    cinsiyetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personeller", x => x.personelNo);
                    table.ForeignKey(
                        name: "FK_personeller_cinsiyetler_cinsiyetId",
                        column: x => x.cinsiyetId,
                        principalTable: "cinsiyetler",
                        principalColumn: "cinsiyetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personeller_cinsiyetId",
                table: "personeller",
                column: "cinsiyetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personeller");

            migrationBuilder.DropTable(
                name: "cinsiyetler");
        }
    }
}
