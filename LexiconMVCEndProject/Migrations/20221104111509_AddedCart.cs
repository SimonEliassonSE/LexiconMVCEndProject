using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVCEndProject.Migrations
{
    public partial class AddedCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4375342d-0159-4c05-9b2a-64a1768f8579", "335757f1-802a-495b-b2e9-4f490f9935f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86d6488e-f207-4dee-925a-d8ac23361c10", "b0b2de94-efed-405f-8998-136ea5aa8093" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4375342d-0159-4c05-9b2a-64a1768f8579", "bf02c0be-58d3-4b94-88be-565976b11f9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4375342d-0159-4c05-9b2a-64a1768f8579", "e1291f95-6c8d-4e7e-b683-2090733f0dd1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4375342d-0159-4c05-9b2a-64a1768f8579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86d6488e-f207-4dee-925a-d8ac23361c10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "335757f1-802a-495b-b2e9-4f490f9935f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0b2de94-efed-405f-8998-136ea5aa8093");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf02c0be-58d3-4b94-88be-565976b11f9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1291f95-6c8d-4e7e-b683-2090733f0dd1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "20cb26a4-c078-4aeb-b7b8-d9924495f702", "User", "USER" },
                    { "9336c3c7-d072-422d-a921-6828d891dd51", "91ae4c32-e26c-4e14-a2e1-8eaad6a9e8dc", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f43054c-46de-43c5-901a-cb37820d89d5", 0, "31e9a18b-c158-4a45-bc10-4f6c2653a791", "test1@test.se", false, false, null, "TEST1@TEST.SE", "TEST1@TEST.SE", "AQAAAAEAACcQAAAAEOe/6E1exg9/5RefZmhhy7g6/hr4v0Z/4/gxpl4opfp0EMUM3w/alOdXo6lT1XlHSA==", null, false, "87ff5e62-79d2-4408-9f29-ce86c261978f", false, "test1@test.se" },
                    { "430cbe72-a50e-4b07-b731-2c2a59e86eab", 0, "171fd790-9f45-486c-aea1-6768b38dfbfe", "test2@test.se", false, false, null, "TEST2@TEST.SE", "TEST2@TEST.SE", "AQAAAAEAACcQAAAAEOlg9Ji2D8Og9FbwRr9HAlvZH3cj068uFGnvblAYW1nHPXZ1Gt7N1qYZ2qjMDqyYFg==", null, false, "e5895a5d-c84a-4afc-ae67-558e8cc87dd9", false, "test2@test.se" },
                    { "bc392b4a-48f8-4033-86e0-a3905d11992d", 0, "1d3e368e-4b30-46b9-84ab-1e6b1e4a9e48", "test4@test.se", false, false, null, "TEST4@TEST.SE", "TEST4@TEST.SE", "AQAAAAEAACcQAAAAENLEBQr+jpXp90TOSjNpdQUNPwXX1ZHw5hvix/qMVlfeHSOLzH1oLIf3epBPU8VCxg==", null, false, "1d3ba67c-a45e-492d-bc48-fc5d22c1de71", false, "test4@test.se" },
                    { "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6", 0, "936f9de3-3274-4e5e-a452-e656fdfb52cd", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEL9aNTX+UhTPsZvv9ouMoNCmanxALoeLUQcR2GWy7iAZhzleoEDSYtSsQK3eZ6IlJw==", null, false, "93dd33a6-3020-4cbc-960d-dc31269357a2", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId", "TotalPrice" },
                values: new object[] { 1, 1, 0.0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "3f43054c-46de-43c5-901a-cb37820d89d5" },
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "430cbe72-a50e-4b07-b731-2c2a59e86eab" },
                    { "4a18a108-c833-499c-907e-f2e8b475a20f", "bc392b4a-48f8-4033-86e0-a3905d11992d" },
                    { "9336c3c7-d072-422d-a921-6828d891dd51", "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "3f43054c-46de-43c5-901a-cb37820d89d5");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "430cbe72-a50e-4b07-b731-2c2a59e86eab");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "bc392b4a-48f8-4033-86e0-a3905d11992d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "3f43054c-46de-43c5-901a-cb37820d89d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "430cbe72-a50e-4b07-b731-2c2a59e86eab" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4a18a108-c833-499c-907e-f2e8b475a20f", "bc392b4a-48f8-4033-86e0-a3905d11992d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9336c3c7-d072-422d-a921-6828d891dd51", "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6" });

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a18a108-c833-499c-907e-f2e8b475a20f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9336c3c7-d072-422d-a921-6828d891dd51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f43054c-46de-43c5-901a-cb37820d89d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430cbe72-a50e-4b07-b731-2c2a59e86eab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc392b4a-48f8-4033-86e0-a3905d11992d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff143f0d-3fab-4bc9-b427-c6f5cfcb54c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4375342d-0159-4c05-9b2a-64a1768f8579", "7b67ca42-c7f2-4464-8509-885b83398ea5", "User", "USER" },
                    { "86d6488e-f207-4dee-925a-d8ac23361c10", "7339e8fe-20c6-49e2-a8ad-e3452e82340f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "335757f1-802a-495b-b2e9-4f490f9935f5", 0, "b59ab84c-5a03-44e5-a3db-51849581249d", "test1@test.se", false, false, null, "TEST1@TEST.SE", "TEST1@TEST.SE", "AQAAAAEAACcQAAAAEGvosBYUs++rzwxQLPpWPN3Re7OenWMPSYLDUwtoFbai565Y32KgI4fsiRUkKHa9+w==", null, false, "129b6da6-7027-44b9-becc-3457b9f63b9d", false, "test1@test.se" },
                    { "b0b2de94-efed-405f-8998-136ea5aa8093", 0, "b9044dd4-e241-45b5-9a73-1f14e6ded07f", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEAmY9HuUm7gkrxPlQzfIIEj3WhUW37RKyan5ENfqktKrmFWfMmCrBSeZF2GCeJM+w==", null, false, "16be559d-6851-4f32-82a9-ff9bd065dc72", false, "admin@admin.com" },
                    { "bf02c0be-58d3-4b94-88be-565976b11f9f", 0, "54cf7322-a998-4350-a274-4461fd58f3c9", "test2@test.se", false, false, null, "TEST2@TEST.SE", "TEST2@TEST.SE", "AQAAAAEAACcQAAAAEJ5EaKRnH/VxrWfYqLD9tt++xSToXpyhmtBnNfNMXnMi/uOHHXGQQC6SgRqPsRtrDw==", null, false, "1ed2459e-295f-4245-befd-6f687bc37377", false, "test2@test.se" },
                    { "e1291f95-6c8d-4e7e-b683-2090733f0dd1", 0, "20febf33-5972-4535-addb-e546d0fafcde", "test4@test.se", false, false, null, "TEST4@TEST.SE", "TEST4@TEST.SE", "AQAAAAEAACcQAAAAEG4Psg+Un0UNLchAAY+6DJ6VbNrNyat9Ztd0a6yDvIeg4nDIPB6f5efceu7WkySFiA==", null, false, "c31a4735-0889-49f5-89b2-aa6fc090aecd", false, "test4@test.se" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4375342d-0159-4c05-9b2a-64a1768f8579", "335757f1-802a-495b-b2e9-4f490f9935f5" },
                    { "86d6488e-f207-4dee-925a-d8ac23361c10", "b0b2de94-efed-405f-8998-136ea5aa8093" },
                    { "4375342d-0159-4c05-9b2a-64a1768f8579", "bf02c0be-58d3-4b94-88be-565976b11f9f" },
                    { "4375342d-0159-4c05-9b2a-64a1768f8579", "e1291f95-6c8d-4e7e-b683-2090733f0dd1" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "335757f1-802a-495b-b2e9-4f490f9935f5");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "bf02c0be-58d3-4b94-88be-565976b11f9f");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "e1291f95-6c8d-4e7e-b683-2090733f0dd1");
        }
    }
}
