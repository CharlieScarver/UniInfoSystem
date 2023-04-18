using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class Student_User_FK_t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_FacNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacNum",
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

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserFacNum",
                table: "Students",
                column: "UserFacNum",
                unique: true,
                filter: "[UserFacNum] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserFacNum",
                table: "Students",
                column: "UserFacNum",
                principalTable: "Users",
                principalColumn: "FacNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserFacNum",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserFacNum",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserFacNum",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
