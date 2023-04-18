using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class Student_User_FK_t8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_FacNum",
                table: "Students",
                column: "FacNum");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacNum",
                table: "Users",
                column: "FacNum",
                unique: true,
                filter: "[FacNum] IS NOT NULL");

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
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_FacNum",
                table: "Users",
                column: "FacNum");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacNum",
                table: "Students",
                column: "FacNum",
                unique: true,
                filter: "[FacNum] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_FacNum",
                table: "Students",
                column: "FacNum",
                principalTable: "Users",
                principalColumn: "FacNum");
        }
    }
}
