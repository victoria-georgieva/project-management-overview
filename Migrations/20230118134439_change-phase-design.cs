using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Migrations
{
    /// <inheritdoc />
    public partial class changephasedesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPhases");

            migrationBuilder.DropTable(
                name: "ProjectPhaseTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BackendDevelopmentPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BackendDevelopmentPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimationPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimationPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FronendDevelopmentPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FronendDevelopmentPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleasePhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleasePhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TestingPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TestingPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UATPhaseFinish",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UATPhaseStart",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AnalysisPhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "BackendDevelopmentPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "BackendDevelopmentPhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EstimationPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EstimationPhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FronendDevelopmentPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FronendDevelopmentPhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ReleasePhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ReleasePhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TestingPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TestingPhaseStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UATPhaseFinish",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UATPhaseStart",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectPhases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectID = table.Column<int>(type: "int", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhaseTypeID = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectPhases_Projects_projectID",
                        column: x => x.projectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhaseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhaseTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhases_projectID",
                table: "ProjectPhases",
                column: "projectID");
        }
    }
}
