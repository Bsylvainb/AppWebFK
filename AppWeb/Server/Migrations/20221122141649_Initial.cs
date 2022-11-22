using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWeb.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ECR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Atelier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmdtC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndiceC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmdtP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndiceP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Analyse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlocT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlocM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FEE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePrio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSoldePr = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateSuivi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RAF = table.Column<int>(type: "int", nullable: false),
                    CommentairePrio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTbem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTbee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTrd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DImi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlSAQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECOCount = table.Column<int>(type: "int", nullable: false),
                    ECOYear = table.Column<int>(type: "int", nullable: false),
                    ECOSelected = table.Column<bool>(type: "bit", nullable: false),
                    ECO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSolde = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Commentaires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFinBE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFinBEE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFinDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFinMI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFinSQ = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "ActionItems",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tilte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItems", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_ActionItems_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_DeveloperId",
                table: "ActionItems",
                column: "DeveloperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItems");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
