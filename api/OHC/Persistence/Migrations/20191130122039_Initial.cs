using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    FactorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FactorType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.FactorID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorType = table.Column<string>(maxLength: 50, nullable: false),
                    FactorName = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Performer = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Interpretation = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: false),
                    NextSurveyDate = table.Column<DateTime>(nullable: false),
                    NormValue = table.Column<string>(nullable: true),
                    Device = table.Column<string>(nullable: true),
                    MarkedParameter = table.Column<string>(nullable: true),
                    IdentificationSurveyMethod = table.Column<string>(nullable: true),
                    DescriptionSurveyMethod = table.Column<string>(nullable: true),
                    IntermediateZoneH = table.Column<string>(nullable: true),
                    IntermediateZoneE = table.Column<string>(nullable: true),
                    RiskZoneE = table.Column<string>(nullable: true),
                    RiskZoneH = table.Column<string>(nullable: true),
                    DengerousZoneE = table.Column<string>(nullable: true),
                    DengerousZoneH = table.Column<string>(nullable: true),
                    Exposure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "FactorPositions",
                columns: table => new
                {
                    FactorId = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorPositions", x => new { x.PositionId, x.FactorId });
                    table.ForeignKey(
                        name: "FK_FactorPositions_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "FactorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactorPositions_FactorId",
                table: "FactorPositions",
                column: "FactorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorPositions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
