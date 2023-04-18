using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class Student_User_FK_t6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_FacNum",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacNum",
                table: "Students",
                column: "FacNum",
                unique: true,
                filter: "[FacNum] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_FacNum",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FacNum",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacNum",
                table: "Students",
                column: "FacNum",
                unique: true);
        }
    }
}
