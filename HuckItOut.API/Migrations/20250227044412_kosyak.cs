using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuckItOut.API.Migrations
{
    /// <inheritdoc />
    public partial class kosyak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Players",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
