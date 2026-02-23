using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Students_AssignedStudentsStudentID",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_AssignedStudentsStudentID",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "AssignedStudentsStudentID",
                table: "BookRequests");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_StudentID",
                table: "BookRequests",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Students_StudentID",
                table: "BookRequests",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Students_StudentID",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_StudentID",
                table: "BookRequests");

            migrationBuilder.AddColumn<int>(
                name: "AssignedStudentsStudentID",
                table: "BookRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_AssignedStudentsStudentID",
                table: "BookRequests",
                column: "AssignedStudentsStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Students_AssignedStudentsStudentID",
                table: "BookRequests",
                column: "AssignedStudentsStudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }
    }
}
