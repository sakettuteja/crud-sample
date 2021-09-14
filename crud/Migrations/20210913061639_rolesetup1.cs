using Microsoft.EntityFrameworkCore.Migrations;

namespace crud.Migrations
{
    public partial class rolesetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e7c884-8c0a-4086-adaf-46ab66f05591", "db195e48-3f20-47a0-bc6c-8b0c48a13bf0", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3386219-42ec-47aa-8446-b522b0d02c99", "7ce9f1ec-9453-4418-98e6-d25a26123317", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e7c884-8c0a-4086-adaf-46ab66f05591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3386219-42ec-47aa-8446-b522b0d02c99");
        }
    }
}
