using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateSCid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseId",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_StudentId",
                table: "StudentsCourse",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_StudentId",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "StudentCourseId",
                table: "StudentsCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                columns: new[] { "StudentId", "CourseId" });
        }
    }
}
