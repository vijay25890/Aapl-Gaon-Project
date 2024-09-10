using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7039",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "441b194f-45f3-4651-be17-bc6479a86f61", "AQAAAAIAAYagAAAAEE4WBYEUnuXSeTSukuVDNiTpXFUNUfgspA8BTKbqfi/bKHppFRWmYV4tbvkUiS198Q==", "7507002561", "56597249-48c9-48ff-9c03-9dac80d8d865" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90b682fd-a6b1-48a3-8663-477ad65d7040", 0, "52c72274-ef73-442e-8d83-81d888081c9b", "shubhamkale@gmail.com", false, false, null, "SHUBHAMKALE@GMAIL.COM", "SHUBHAMKALE@GMAIL.COM", "AQAAAAIAAYagAAAAEIo9gIlM9XzB5YvzLVqIgNVBR3VyQ5KXLc0Wp1JeI84K48Q6nCZZ3+WwO7oq4wUIVw==", "9145676968", false, "589d7816-2ef9-433f-8ed2-370b4cbbcb88", false, "shubhamkale@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2bc7d74c-f1f3-4d79-91ad-338f381a9bb9", "90b682fd-a6b1-48a3-8663-477ad65d7040" },
                    { "4da6bcdb-80fe-4569-832f-7809e2cd9332", "90b682fd-a6b1-48a3-8663-477ad65d7040" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bc7d74c-f1f3-4d79-91ad-338f381a9bb9", "90b682fd-a6b1-48a3-8663-477ad65d7040" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4da6bcdb-80fe-4569-832f-7809e2cd9332", "90b682fd-a6b1-48a3-8663-477ad65d7040" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7040");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b682fd-a6b1-48a3-8663-477ad65d7039",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6e662c5a-e505-4426-a9b6-19468f299f7d", "AQAAAAIAAYagAAAAEIF6HTdI7nCSj2XZz15I8a72atN9Ri4MGE3iKzoGbrViTERn/hrN8LL2z6y5E4pFfQ==", null, "8dfb23f4-bf31-4934-9b6f-f9bb8d8f9f56" });
        }
    }
}
