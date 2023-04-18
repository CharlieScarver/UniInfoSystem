using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class Student_User_FK_t5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_FacNum",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FacNum",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Students_FacNum",
                table: "Students");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_FacNum",
                table: "Users",
                column: "FacNum");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacNum",
                table: "Students",
                column: "FacNum",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_FacNum",
                table: "Students",
                column: "FacNum",
                principalTable: "Users",
                principalColumn: "FacNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_FacNum",
                table: "Students");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_FacNum",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacNum",
                table: "Students");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_FacNum",
                table: "Students",
                column: "FacNum");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacNum",
                table: "Users",
                column: "FacNum",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_FacNum",
                table: "Users",
                column: "FacNum",
                principalTable: "Students",
                principalColumn: "FacNum");
        }
    }
}
