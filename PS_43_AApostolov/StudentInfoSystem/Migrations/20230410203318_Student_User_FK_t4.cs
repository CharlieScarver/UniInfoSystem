using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class Student_User_FK_t4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserFacNum",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_FacNum",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserFacNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserFacNum",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserFacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_FacNum",
                table: "Users",
                column: "FacNum");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserFacNum",
                table: "Students",
                column: "UserFacNum",
                unique: true,
                filter: "[UserFacNum] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserFacNum",
                table: "Students",
                column: "UserFacNum",
                principalTable: "Users",
                principalColumn: "FacNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
