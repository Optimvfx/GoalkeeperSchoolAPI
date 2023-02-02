using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalkeeperSchoolDataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SchemaComponentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeeperProfiles_Accounts_AccountID",
                table: "GoalkeeperProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeeperProfiles_FullNames_FullNameID",
                table: "GoalkeeperProfiles");

            migrationBuilder.RenameColumn(
                name: "FullNameID",
                table: "GoalkeeperProfiles",
                newName: "DbFullNameID");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "GoalkeeperProfiles",
                newName: "DBAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_GoalkeeperProfiles_FullNameID",
                table: "GoalkeeperProfiles",
                newName: "IX_GoalkeeperProfiles_DbFullNameID");

            migrationBuilder.RenameIndex(
                name: "IX_GoalkeeperProfiles_AccountID",
                table: "GoalkeeperProfiles",
                newName: "IX_GoalkeeperProfiles_DBAccountID");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "FullNames",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Paternity",
                table: "FullNames",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FullNames",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeeperProfiles_Accounts_DBAccountID",
                table: "GoalkeeperProfiles",
                column: "DBAccountID",
                principalTable: "Accounts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeeperProfiles_FullNames_DbFullNameID",
                table: "GoalkeeperProfiles",
                column: "DbFullNameID",
                principalTable: "FullNames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeeperProfiles_Accounts_DBAccountID",
                table: "GoalkeeperProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeeperProfiles_FullNames_DbFullNameID",
                table: "GoalkeeperProfiles");

            migrationBuilder.RenameColumn(
                name: "DbFullNameID",
                table: "GoalkeeperProfiles",
                newName: "FullNameID");

            migrationBuilder.RenameColumn(
                name: "DBAccountID",
                table: "GoalkeeperProfiles",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_GoalkeeperProfiles_DbFullNameID",
                table: "GoalkeeperProfiles",
                newName: "IX_GoalkeeperProfiles_FullNameID");

            migrationBuilder.RenameIndex(
                name: "IX_GoalkeeperProfiles_DBAccountID",
                table: "GoalkeeperProfiles",
                newName: "IX_GoalkeeperProfiles_AccountID");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "FullNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Paternity",
                table: "FullNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FullNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeeperProfiles_Accounts_AccountID",
                table: "GoalkeeperProfiles",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeeperProfiles_FullNames_FullNameID",
                table: "GoalkeeperProfiles",
                column: "FullNameID",
                principalTable: "FullNames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
