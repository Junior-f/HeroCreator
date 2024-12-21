using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroCreator.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsToLowerCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "characters");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "characters",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "characters",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "characters",
                newName: "inventory");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "characters",
                newName: "class");

            migrationBuilder.RenameColumn(
                name: "Attributes",
                table: "characters",
                newName: "attributes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "characters",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "level",
                table: "characters",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_characters",
                table: "characters",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_characters",
                table: "characters");

            migrationBuilder.RenameTable(
                name: "characters",
                newName: "Characters");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Characters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Characters",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "inventory",
                table: "Characters",
                newName: "Inventory");

            migrationBuilder.RenameColumn(
                name: "class",
                table: "Characters",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "attributes",
                table: "Characters",
                newName: "Attributes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Characters",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Characters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");
        }
    }
}
