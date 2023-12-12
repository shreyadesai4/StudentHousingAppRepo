using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHousingApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "LandlordID",
                table: "Properties",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TempLandlordID",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties",
                column: "LandlordID",
                principalTable: "Landlords",
                principalColumn: "LandlordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TempLandlordID",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "LandlordID",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties",
                column: "LandlordID",
                principalTable: "Landlords",
                principalColumn: "LandlordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
