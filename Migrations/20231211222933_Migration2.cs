using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHousingApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Landlords_LandlordID",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameIndex(
                name: "IX_Property_LandlordID",
                table: "Properties",
                newName: "IX_Properties_LandlordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties",
                column: "LandlordID",
                principalTable: "Landlords",
                principalColumn: "LandlordID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordID",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_LandlordID",
                table: "Property",
                newName: "IX_Property_LandlordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Landlords_LandlordID",
                table: "Property",
                column: "LandlordID",
                principalTable: "Landlords",
                principalColumn: "LandlordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
