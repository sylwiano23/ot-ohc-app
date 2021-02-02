using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddAdditionalPropertiesToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceKind",
                table: "Surveys",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSurveySuspend",
                table: "Surveys",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceKind",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IsSurveySuspend",
                table: "Surveys");
        }
    }
}
