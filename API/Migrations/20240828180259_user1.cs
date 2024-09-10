using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class user1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7039",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d85533ec-52a9-48a5-bb44-c1feef1706b5", "AQAAAAIAAYagAAAAEP2SQckCmbQhRgixnmZ3fiz+AntofmpqcJp6TIvecZk2ETsjDt36ciamxLEus/BQrg==", "1dd96fa3-16a7-47ff-8d56-ccb19aea0f5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f3ba029-b7c8-4fef-88d9-3c63436b27b7", "AQAAAAIAAYagAAAAECoMXOCok2BUjuxat4NFdqN3zjNPeT9Ndla8iLe84wfxneVos7nFnQA2zXGnaeFtyQ==", "7a7adc55-f148-4342-9af2-7f8addf3b200" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7039",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "441b194f-45f3-4651-be17-bc6479a86f61", "AQAAAAIAAYagAAAAEE4WBYEUnuXSeTSukuVDNiTpXFUNUfgspA8BTKbqfi/bKHppFRWmYV4tbvkUiS198Q==", "56597249-48c9-48ff-9c03-9dac80d8d865" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c72274-ef73-442e-8d83-81d888081c9b", "AQAAAAIAAYagAAAAEIo9gIlM9XzB5YvzLVqIgNVBR3VyQ5KXLc0Wp1JeI84K48Q6nCZZ3+WwO7oq4wUIVw==", "589d7816-2ef9-433f-8ed2-370b4cbbcb88" });
        }
    }
}
