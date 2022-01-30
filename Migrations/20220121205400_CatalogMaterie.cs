using Microsoft.EntityFrameworkCore.Migrations;

namespace Retegan_Andra_proiect2.Migrations
{
    public partial class CatalogMaterie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorID",
                table: "Catalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMaterie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProfesor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CatalogMaterie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogID = table.Column<int>(nullable: false),
                    MaterieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogMaterie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatalogMaterie_Catalog_CatalogID",
                        column: x => x.CatalogID,
                        principalTable: "Catalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogMaterie_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProfesorID",
                table: "Catalog",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogMaterie_CatalogID",
                table: "CatalogMaterie",
                column: "CatalogID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogMaterie_MaterieID",
                table: "CatalogMaterie",
                column: "MaterieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Profesor_ProfesorID",
                table: "Catalog",
                column: "ProfesorID",
                principalTable: "Profesor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Profesor_ProfesorID",
                table: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogMaterie");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_ProfesorID",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "ProfesorID",
                table: "Catalog");
        }
    }
}
