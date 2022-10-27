using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVCEndProject.Migrations
{
    public partial class AddedrolesanddefaultAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6f147ec-5738-4103-a53c-0ce423e77379", "3bc42f8e-b53b-4a84-af87-a00751c8afcd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaf49ea1-5ea8-4db9-824d-101a94a2418f", "20822350-cecc-4972-af5e-d2c8f2c848fa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af0f780c-d573-4f0c-9d8f-22d1848bfe1c", 0, "6f713833-cc95-47ca-bd41-fc7f20dc52a6", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKuhwYs9KsJHNS9gJJIo1p4zmRzly1TLU/oe0fjs81oS+Mw5+zLYpecMzTHoqWbhbw==", null, false, "09b24947-76a6-47cd-821e-771ed8d209bc", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eaf49ea1-5ea8-4db9-824d-101a94a2418f", "af0f780c-d573-4f0c-9d8f-22d1848bfe1c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6f147ec-5738-4103-a53c-0ce423e77379");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eaf49ea1-5ea8-4db9-824d-101a94a2418f", "af0f780c-d573-4f0c-9d8f-22d1848bfe1c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaf49ea1-5ea8-4db9-824d-101a94a2418f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af0f780c-d573-4f0c-9d8f-22d1848bfe1c");
        }
    }
}
